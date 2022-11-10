using System.Collections;
using UnityEngine;

public abstract class BasePlatform : MonoBehaviour
{
    protected CameraViewWidth _cameraViewWidth;
    protected Animator _animator;
    protected AudioSource _soundEffect;
    protected Rigidbody2D _platformRigidbody;

    public float PushPower;

    protected bool _toStop = true;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _soundEffect = GetComponent<AudioSource>();
        _platformRigidbody = GetComponent<Rigidbody2D>();

        _cameraViewWidth = GameObject.Find("Main Camera").GetComponent<CameraViewWidth>();

    }
    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        _soundEffect.Play();
        var target = other.gameObject;
        Rigidbody2D rb = target.GetComponent<Rigidbody2D>();
        Vector2 velocity = rb.velocity;
        velocity.y = PushPower;
        rb.velocity = velocity;
    }

    protected IEnumerator PlatformMove(GameObject _platform, float xMin, float xMax )
    {
        Vector2 _leftEdgePosition = new Vector2(xMin, _platform.transform.position.y);
        Vector2 _rightEdgePosition = new Vector2(xMax, _platform.transform.position.y);

        while (true)
        {
            yield return new WaitForFixedUpdate();
            if (_platform != null)
            {
                Vector2 _tempPosition = (Vector2)_platform.transform.position;

                if (_toStop)
                {
                    _tempPosition = Vector2.MoveTowards(_tempPosition, _rightEdgePosition, 1 * Time.deltaTime);
                    _platform.transform.position = _tempPosition;
                    if ((Vector2)_platform.transform.position == _rightEdgePosition)
                    {
                        _toStop = false;
                    }
                }
                else if (!_toStop)
                {
                    _tempPosition = Vector2.MoveTowards(_tempPosition, _leftEdgePosition, 1 * Time.deltaTime);
                    _platform.transform.position = _tempPosition;
                    if ((Vector2)_platform.transform.position == _leftEdgePosition)
                    {
                        _toStop = true;
                    }
                }
            }
            else yield break;
        }
    }
    public virtual void MovePlatform(GameObject prefab, float y, float xMin , float xMax)
    {
        if (y > 1)
        {
            if (RandomSelection.RandomGenerate(0.3f) == true)
            {
                StartCoroutine(PlatformMove(prefab, xMin, xMax));
            }
        }
    }
}
