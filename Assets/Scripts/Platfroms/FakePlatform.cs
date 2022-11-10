using UnityEngine;

public class FakePlatform : BasePlatform
{ 
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        _animator.Play("Broke");
        base.OnCollisionEnter2D(collision);
        Destroy(gameObject, 0.2f);
    }
}
