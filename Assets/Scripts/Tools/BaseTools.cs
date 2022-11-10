using UnityEngine;

public abstract class BaseTools : MonoBehaviour
{
    [HideInInspector] public Animator Animator;
    [HideInInspector] public AudioSource SoundEffect;

    public float PushPower;
    private void Awake()
    {
        Animator = GetComponent<Animator>();
        SoundEffect = GetComponent<AudioSource>();
    }
    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            var target = other.gameObject;

            Rigidbody2D rb = target.GetComponent<Rigidbody2D>();
            Vector2 velocity = rb.velocity;
            velocity.y = PushPower;
            rb.velocity = velocity;
            SoundEffect.Play();
        }
    }
}
