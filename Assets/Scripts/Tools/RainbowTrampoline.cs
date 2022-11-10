using UnityEngine;

public class RainbowTrampoline : BaseTools
{
    public override void OnTriggerEnter2D(Collider2D other)
    {
        Animator.Play("Trampoline");
        base.OnTriggerEnter2D(other);
    }
}
