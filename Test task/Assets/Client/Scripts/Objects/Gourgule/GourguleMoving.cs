using UnityEngine;

public class GourguleMoving : MonoBehaviour 
{
    public float HorizontalSpeed;
    public float ScalerOfSpeed;

    void Start()
    {
        HorizontalSpeed = Screen.width / ScalerOfSpeed; 
    }

    void FixedUpdate()//TODO сделать синусоидное движение мыфки
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
