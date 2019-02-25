using UnityEngine;

public class CornerCoordinates : MonoBehaviour
{
    RectTransform rt;

    void Start()
    {
        rt = GetComponent<RectTransform>();
        DisplayWorldCorners();
    }

    void DisplayWorldCorners()
    {
        Vector3[] v = new Vector3[4];
        rt.GetWorldCorners(v);

        /*Debug.Log("World Corners");
        for (var i = 0; i < 4; i++)
        {
            Debug.Log("World Corner " + i + " : " + v[i]);
        }*/
    }
}
