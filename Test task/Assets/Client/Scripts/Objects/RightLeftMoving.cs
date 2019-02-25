using UnityEngine;

public class RightLeftMoving : MonoBehaviour
{
    public bool IsLeft;

    void FixedUpdate()
    {
        if (IsLeft)
        {
            Vector3 position = new Vector3(gameObject.transform.position.x - 0.5f, gameObject.transform.position.y, gameObject.transform.position.z);
            gameObject.transform.position = position;
        }
        else
        {
            Vector3 position = new Vector3(gameObject.transform.position.x + 0.5f, gameObject.transform.position.y, gameObject.transform.position.z);
            gameObject.transform.position = position;
        }
    }
}
