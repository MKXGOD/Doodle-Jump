using UnityEngine;

public class DefaultPlatform : BasePlatform
{
    private void Start()
    {
        MovePlatform(this.gameObject, this.gameObject.transform.position.y, _cameraViewWidth.xMin, _cameraViewWidth.xMax);
    }
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }
    public override void MovePlatform(GameObject prefab, float y, float xMin, float xMax)
    {
        base.MovePlatform(prefab, y, xMin, xMax);
    }
    
}
