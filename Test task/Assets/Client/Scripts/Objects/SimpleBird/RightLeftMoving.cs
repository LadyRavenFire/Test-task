using UnityEngine;

public class RightLeftMoving : MonoBehaviour
{
    public bool IsLeft;
    public float HorizontalSpeed;
    public float VerticalSpeed;

    void Start()
    {
        HorizontalSpeed = Screen.width/250;
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
