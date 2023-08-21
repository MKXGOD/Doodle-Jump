using UnityEngine;

public class PigControl : MonoBehaviour
{
    public delegate void HeightEventHandler();
    public event HeightEventHandler HeightChanged;

    private Rigidbody2D _pigRigidbody;
    private SpriteRenderer _pigSprite;
    private BoxCollider2D _pigBoxCollider;
    private Animator _pigAnimator;

    private bool _isAlive;
    public bool IsAlive => _isAlive;
    public bool SideChangeble = true;
    [HideInInspector] public int MaxHeight;
    [HideInInspector] public Vector2 _velocity;

    [SerializeField] private float _speed;
    private float _horizontal;

    private void Awake()
    {
        _pigRigidbody = GetComponent<Rigidbody2D>();
        _pigSprite = GetComponent<SpriteRenderer>();
        _pigBoxCollider = GetComponent<BoxCollider2D>();
        _pigAnimator = GetComponent<Animator>();

        PigState(true);
    }
    private void Update()
    {
        if(Application.isEditor)
            _horizontal = Input.GetAxis("Horizontal") * _speed;
        else if (Application.isPlaying)
            _horizontal = Input.acceleration.x * _speed;

        //change side when going out of screen
        FlightToTheOppoiteSide();

        SetMaxHeight();
        Fly();
        ChangingSpriteDirection();
    }
    private void FixedUpdate()
    {
        _velocity = _pigRigidbody.velocity;
        _velocity.x = _horizontal;
        _pigRigidbody.velocity = _velocity;
    }
    public void Jump(float pushPower)
    {
        _velocity.y = pushPower;
        _pigRigidbody.velocity = _velocity;
    }
    public void PigState(bool state)
    { 
        _isAlive = state;
    }
    private void FlightToTheOppoiteSide()
    {
        if (transform.position.x > 2.6f && _pigSprite.flipX == true)
            transform.position = new Vector3(-transform.position.x, transform.position.y, transform.position.z);
        else if (transform.position.x < -2.6f && _pigSprite.flipX != true)
            transform.position = new Vector3(-transform.position.x, transform.position.y, transform.position.z);
    }
    private void SetMaxHeight()
    {
        if ((int)transform.position.y > MaxHeight)
        {
            MaxHeight = (int)transform.position.y;
            HeightChanged?.Invoke();
        }
    }
    private void Fly()
    {
        //Collider stops working during takeoff
        if (IsFlying())
        {
            _pigAnimator.SetBool("_isJumping", true);
            _pigBoxCollider.enabled = false;
        }
        else
        {
            _pigAnimator.SetBool("_isJumping", false);
            _pigBoxCollider.enabled = true;
        }
    }
    private bool IsFlying()
    {
        if (_velocity.y > 1)
            return true;
        else if (_velocity.y < 1)
            return false;

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
