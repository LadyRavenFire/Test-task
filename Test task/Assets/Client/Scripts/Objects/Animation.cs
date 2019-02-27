﻿using UnityEngine;
using UnityEngine.UI;

public class Animation : MonoBehaviour
{

#pragma warning disable 649
    [SerializeField] private Sprite[] _frames;
#pragma warning restore 649
#pragma warning disable 649
    [SerializeField] private GameObject _relative;
#pragma warning restore 649
    [SerializeField] float framesPerSecond;
    [SerializeField] private float _rotationY;

    private Image _image;

    private IsLeftMoving _IsLeftMoving;

    void Start()
    {
        _IsLeftMoving = _relative.GetComponent<IsLeftMoving>();
        _image = gameObject.GetComponent<Image>();
        _rotationY = gameObject.transform.rotation.y;

        Rotation(); 
    }


    void FixedUpdate()
    {
        int index = (int)(Time.time * framesPerSecond) % _frames.Length;
        _image.sprite = _frames[index];
    }

    public void Rotation()
    {
        if (_IsLeftMoving.IsLeft)
        {
            if (_rotationY == gameObject.transform.rotation.y)
            {
                Quaternion rotate = new Quaternion(gameObject.transform.rotation.x, gameObject.transform.rotation.y - 360, gameObject.transform.rotation.z, 0);
                _image.transform.rotation = rotate;
            }        
        }
    }
}