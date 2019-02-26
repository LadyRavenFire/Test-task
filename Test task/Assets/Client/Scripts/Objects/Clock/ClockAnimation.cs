using UnityEngine;
using UnityEngine.UI;

public class ClockAnimation : MonoBehaviour
{
    [SerializeField] private Sprite[] _frames;
    [SerializeField] float framesPerSecond = 10f;
    private Image _image;

    void Start()
    {
        _image = gameObject.GetComponent<Image>();
    }

    void FixedUpdate()
    {
        int index = (int)(Time.time * framesPerSecond) % _frames.Length;
        _image.sprite = _frames[index];
    }
}
    