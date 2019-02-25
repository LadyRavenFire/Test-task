using UnityEngine;
using UnityEngine.UI;

public class Animation : MonoBehaviour
{

    [SerializeField] private Sprite[] _frames;
    [SerializeField] private GameObject _relative;
    [SerializeField] float framesPerSecond = 10f;
    [SerializeField] private float _rotationY;

    private Image _image;

    private RightLeftMoving _rightLeftMoving;

    void Start()
    {
        _rightLeftMoving = _relative.GetComponent<RightLeftMoving>();
        _image = gameObject.GetComponent<Image>();
        _rotationY = gameObject.transform.rotation.y;

        Rotation(); 
    }


    void OnGUI()
    {
        int index = (int)(Time.time * framesPerSecond) % _frames.Length;
        _image.sprite = _frames[index];
    }

    public void Rotation()
    {
        if (_rightLeftMoving.IsLeft)
        {
            if (_rotationY == gameObject.transform.rotation.y)
            {
                Quaternion rotate = new Quaternion(gameObject.transform.rotation.x, gameObject.transform.rotation.y - 360, gameObject.transform.rotation.z, 0);
                _image.transform.rotation = rotate;
            }        
        }
    }
}
