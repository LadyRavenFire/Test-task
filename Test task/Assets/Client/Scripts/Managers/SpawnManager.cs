﻿using UnityEngine;
using Random = System.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _simpleObject;
    [SerializeField] private Canvas _mainCanvas;

    [SerializeField] private CornerCoordinates _cornerCoordinates;
    private Random _random;

    private float _delay;


    void Start()
    {
        _random = new Random();
        _cornerCoordinates = _mainCanvas.GetComponent<CornerCoordinates>();
        _delay = 2f;
    }

    void FixedUpdate()
    {
        if (_delay > 0)
        {
            _delay = _delay - Time.deltaTime;
        }
        else
        {
            _delay = 2f;
            int leftRight = _random.Next(0, 2);
            if (leftRight == 0)
            {
                int yCoord = (int)_random.Next(0, (int)_cornerCoordinates.ScreenSpaceCorners[2].y);
                var newObject = Instantiate(_simpleObject, new Vector3(10, 10, 0), Quaternion.identity) as GameObject;

                newObject.transform.SetParent(_mainCanvas.transform, false);
                newObject.transform.position = new Vector3((int)_cornerCoordinates.ScreenSpaceCorners[2].x - 10, yCoord, 0);
            }
            else
            {
                int yCoord = (int)_random.Next(0, (int)_cornerCoordinates.ScreenSpaceCorners[2].y);
                var newObject = Instantiate(_simpleObject, new Vector3(10, 10, 0), Quaternion.identity) as GameObject;

                newObject.transform.SetParent(_mainCanvas.transform, false);
                newObject.transform.position = new Vector3(10, yCoord, 0);

                RightLeftMoving rightLeftMoving = newObject.GetComponent<RightLeftMoving>();
                rightLeftMoving.IsLeft = false;                
            }
        }
    }

    
}
