using UnityEngine;

public class RightLeftMoving : MonoBehaviour
{
    public bool IsLeft;
    private CornerCoordinates _cornerCoordinates;
    public float HorizontalSpeed;
    public float VerticalSpeed;

    void Start()
    {
        _cornerCoordinates = GameObject.Find("MainCanvas").GetComponent<CornerCoordinates>();
        HorizontalSpeed = _cornerCoordinates.ScreenSpaceCorners[3].x/1000;
    }

    void FixedUpdate()
    {
        if (IsLeft)
        {
            Vector3 position = new Vector3(gameObject.transform.position.x - HorizontalSpeed, gameObject.transform.position.y, gameObject.transform.position.z);
            gameObject.transform.position = position;
        }
        else
        {
            Vector3 position = new Vector3(gameObject.transform.position.x + HorizontalSpeed, gameObject.transform.position.y, gameObject.transform.position.z);
            gameObject.transform.position = position;
        }
    }
}
