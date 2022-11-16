using UnityEngine;
using System.Collections;

public class Wings : BaseTools
{
    public override void OnTriggerEnter2D(Collider2D other)
    {
       base.OnTriggerEnter2D(other);
        if (other.gameObject.tag == "Player")
            StartCoroutine(EquippedWings(other.gameObject));
    }
    private IEnumerator EquippedWings(GameObject pig)
    {
        this.gameObject.transform.SetParent(pig.transform, true);
        this.gameObject.transform.localScale = new Vector2(4, 4);
        this.gameObject.transform.localPosition = new Vector2(pig.transform.localPosition.x, pig.transform.localPosition.y);
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
            
    }
}
