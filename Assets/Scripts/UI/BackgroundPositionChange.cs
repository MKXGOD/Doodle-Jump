using UnityEngine;

public class BackgroundPositionChange : MonoBehaviour
{
    [SerializeField]private SpriteRenderer _sprite;
    [SerializeField]private GameObject _pig;

    public float _positionY;

    private void Awake()
    {
        _positionY = _sprite.bounds.size.y * 2;
        
    }

    private void Update()
    {
        if (_pig != null)
        {
            if (_pig.transform.position.y >= _positionY)
            {
                transform.position = new Vector2(0, _pig.transform.position.y);
                _positionY += 20;
            }
        }
    }
}
