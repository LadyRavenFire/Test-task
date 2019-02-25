using UnityEngine;
using UnityEngine.UI;

public class Animation : MonoBehaviour
{

    [SerializeField]
    Sprite[] _frames;

    [SerializeField]
    float framesPerSecond = 10f;

    private Image _image;

    private RightLeftMoving _rightLeftMoving;

    void Start()
    {
        _rightLeftMoving = gameObject.GetComponent<RightLeftMoving>();
        _image = gameObject.GetComponent<Image>();

        if (_rightLeftMoving.IsLeft)
        {
            //Quaternion rotate = new Quaternion(gameObject.transform.rotation.x, gameObject.transform.rotation.y+360, gameObject.transform.rotation.z, 0);
            //transform.localRotation = rotate;  -- non clicked
           
        }
    }

    // Update is called once per frame
    void OnGUI()
    {
        int index = (int)(Time.time * framesPerSecond) % _frames.Length;
        _image.sprite = _frames[index];
    }
}
