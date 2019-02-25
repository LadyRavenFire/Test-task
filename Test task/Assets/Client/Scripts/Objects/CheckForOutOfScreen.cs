using UnityEngine;

public class CheckForOutOfScreen : MonoBehaviour
{
    private CornerCoordinates _cornerCoordinates;

    void Start()
    {
        _cornerCoordinates = GameObject.Find("MainCanvas").GetComponent<CornerCoordinates>();
    }
  
    void FixedUpdate()
    {
        if (gameObject.transform.position.x < _cornerCoordinates.ScreenSpaceCorners[0].x)
        {
            print("left");
        }

        if (gameObject.transform.position.x > _cornerCoordinates.ScreenSpaceCorners[3].x)
        {
            print("right");
        }
    }
}
