using UnityEngine;

public class RightLeftMoving : MonoBehaviour
{
    public bool IsLeft;
    private CornerCoordinates _cornerCoordinates;
    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private float _verticalSpeed;

    void Start()
    {
        _cornerCoordinates = GameObject.Find("MainCanvas").GetComponent<CornerCoordinates>();
        _horizontalSpeed = _cornerCoordinates.ScreenSpaceCorners[3].x/1000;
    }

    void FixedUpdate()
    {
        if (IsLeft)
        {
            Vector3 position = new Vector3(gameObject.transform.position.x - _horizontalSpeed, gameObject.transform.position.y, gameObject.transform.position.z);
            gameObject.transform.position = position;
        }
        else
        {
            Vector3 position = new Vector3(gameObject.transform.position.x + _horizontalSpeed, gameObject.transform.position.y, gameObject.transform.position.z);
            gameObject.transform.position = position;
        }
    }
}
