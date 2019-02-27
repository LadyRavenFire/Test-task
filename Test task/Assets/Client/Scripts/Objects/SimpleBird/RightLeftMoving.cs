using UnityEngine;
using Random = System.Random;

public class RightLeftMoving : MonoBehaviour
{
    public float HorizontalSpeed;
    private int _scaler;

    void Start()
    {        
        HorizontalSpeed = Screen.width;
        _scaler = GameObject.Find("LevelManager").GetComponent<SpawnManager>().Random.Next(170, 250);
        HorizontalSpeed = HorizontalSpeed / _scaler;
        
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
