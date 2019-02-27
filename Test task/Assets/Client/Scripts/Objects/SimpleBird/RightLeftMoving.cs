using UnityEngine;

public class RightLeftMoving : MonoBehaviour
{
    public float HorizontalSpeed;

    void Start()
    {
        HorizontalSpeed = Screen.width/250;
    }

    void FixedUpdate()
    {
        if (gameObject.GetComponent<IsLeftMoving>().IsLeft)
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
