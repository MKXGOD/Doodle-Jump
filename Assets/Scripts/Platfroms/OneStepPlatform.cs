using UnityEngine;

public class OneStepPlatform : BasePlatform
{
    protected override void OnCollisionEnter2D(Collision2D other)
    {
        base.OnCollisionEnter2D(other);
        Destroy(this.gameObject, 0.2f);
    }
}
