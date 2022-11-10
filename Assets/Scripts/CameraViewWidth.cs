using UnityEngine;

public class CameraViewWidth : MonoBehaviour
{
    private Camera MainCamera;

    public float xMin 
    {
        get => MainCamera.ViewportToWorldPoint(new Vector2(0,0)).x; 
    }
    public  float xMax 
    {
        get => MainCamera.ViewportToWorldPoint(new Vector2(1, 0)).x;
    }
    private void Awake()
    {
        MainCamera = GetComponent<Camera>();
    }
}
