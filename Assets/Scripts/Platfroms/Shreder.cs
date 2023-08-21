using UnityEngine;

public class Shreder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != null && collision.gameObject.tag != "Player")
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            var target = collision.gameObject;
            target.TryGetComponent<PigControl>(out PigControl pig);
            pig.PigState(false);
        }
    }
}
