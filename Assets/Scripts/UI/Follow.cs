using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField]private GameObject _pig;
    [SerializeField]private GameObject _slave;

    public float Offset;

    private float _slavePositionY;
    private void Update()
    {
        if (_pig != null)
        {
            _slavePositionY = _pig.transform.position.y;
            _slave.transform.position = new Vector3(_slave.transform.position.x, Mathf.Clamp(_slave.transform.position.y, _slavePositionY + Offset, _slave.transform.position.y), _slave.transform.position.z);
        }
    }
}
