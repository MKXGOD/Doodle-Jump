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
            var _pig = pig.gameObject.GetComponent<PigControl>();
            _pig.SideChangeble = false;


            this.gameObject.transform.SetParent(pig.transform, true);
            this.gameObject.transform.localPosition = new Vector2(pig.transform.localPosition.x + 7, pig.transform.localPosition.y + 9);

            yield return new WaitForSeconds(3);
            _pig.SideChangeble = true;
            Destroy(this.gameObject);
            
    }
}
