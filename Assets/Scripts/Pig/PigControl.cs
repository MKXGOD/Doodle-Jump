using UnityEngine;

public class PigControl : MonoBehaviour
{
    public delegate void HeightEventHandler();
    public event HeightEventHandler HeightChanged;

    private Rigidbody2D _pigRigidbody;
    private SpriteRenderer _pigSprite;
    private BoxCollider2D _pigBoxCollider;
    private Animator _pigAnimator;

    public bool IsAlive;
    public bool SideChangeble = true;
    public int MaxHeight;
    
    [SerializeField] private float _speed;

    private float _horizontal;
    public Vector2 _velocity;
    
    private void Awake()
    {
        _pigRigidbody = GetComponent<Rigidbody2D>();
        _pigSprite = GetComponent<SpriteRenderer>();
        _pigBoxCollider = GetComponent<BoxCollider2D>();
        _pigAnimator = GetComponent<Animator>();

        IsAlive = true;
    }
    private void Update()
    {
        if(Application.isEditor)
            _horizontal = Input.GetAxis("Horizontal") * _speed;
        else if (Application.isPlaying)
            _horizontal = Input.acceleration.x * _speed;

            //change side when going out of screen
            if (transform.position.x > 2.6f)
                transform.position = new Vector3(-transform.position.x, transform.position.y, transform.position.z);
            else if (transform.position.x < -2.6f)
                transform.position = new Vector3(-transform.position.x, transform.position.y, transform.position.z);

        //Set Max Height 
        if ((int)transform.position.y > MaxHeight)
        {
            MaxHeight = (int)transform.position.y;
            HeightChanged?.Invoke();
        }

        //Collider stops working during takeoff
        if (Fly() == true)
        {
            _pigAnimator.SetBool("_isJumping", true);
            _pigBoxCollider.enabled = false;
        }
        else
        {
            _pigAnimator.SetBool("_isJumping", false);
            _pigBoxCollider.enabled = true;
        }

        ChangingSpriteDirection();
    }
    public void FixedUpdate()
    {
        _velocity = _pigRigidbody.velocity;
        _velocity.x = _horizontal;
        _pigRigidbody.velocity = _velocity;
    }
    public bool Fly()
    {
        if (_velocity.y > 1)
        {
            return true;
        }
        else if (_velocity.y < 1)
        {
            return false;
        }

        return default;
    }
    private void ChangingSpriteDirection()
    {
        if (SideChangeble == true)
        {
            if (_velocity.x >= 0)
                _pigSprite.flipX = true;
            else _pigSprite.flipX = false;
        }
        else _pigSprite.flipX = false;
    }
}
