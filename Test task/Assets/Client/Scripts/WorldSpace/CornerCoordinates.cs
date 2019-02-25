using UnityEngine;

public class CornerCoordinates : MonoBehaviour
{
    public RectTransform RectTransform;
    public Vector3[] ScreenSpaceCorners;

    void Start()
    {
        RectTransform = GetComponent<RectTransform>();
        ScreenSpaceCorners = new Vector3[4];
        RectTransform.GetWorldCorners(ScreenSpaceCorners);      
    }
}
