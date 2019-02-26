using UnityEngine;
using Random = System.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _simpleObject;
    [SerializeField] private GameObject _boomEffect;


    [SerializeField] private Canvas _mainCanvas;

    [SerializeField] private CornerCoordinates _cornerCoordinates;
    private Random _random;

    private float _delay;


    void Start()
    {
        _random = new Random();
        _cornerCoordinates = _mainCanvas.GetComponent<CornerCoordinates>();
        _delay = _random.Next(0,3);
    }

    void FixedUpdate()
    {
        if (_delay > 0)
        {
            _delay = _delay - Time.deltaTime;
        }
        else
        {
            SpawnBird();
        }
    }

    void SpawnBird()
    {
        _delay = _random.Next(0, 3);
        int leftRight = _random.Next(0, 2);
        int borderOfScreen = (int)(_cornerCoordinates.ScreenSpaceCorners[2].y * 0.1f); //TODO калибровать значения

        int yCoord = (int)_random.Next(0 + borderOfScreen, (int)_cornerCoordinates.ScreenSpaceCorners[2].y - borderOfScreen); //TODO ScreenWidthm, ScreenHeight.
        var newObject = Instantiate(_simpleObject, new Vector3(10, 10, 0), Quaternion.identity) as GameObject;
        newObject.transform.SetParent(_mainCanvas.transform, false);

        if (leftRight == 0)
        {
            newObject.transform.position = new Vector3((int)_cornerCoordinates.ScreenSpaceCorners[2].x + (_cornerCoordinates.ScreenSpaceCorners[2].x * 0.1f), yCoord, 0);
        }
        else
        {
            newObject.transform.position = new Vector3(-(_cornerCoordinates.ScreenSpaceCorners[2].x * 0.1f), yCoord, 0);
            RightLeftMoving rightLeftMoving = newObject.GetComponent<RightLeftMoving>();
            rightLeftMoving.IsLeft = false;
        }
    }

    public void SpawnBoom(Vector3 place)
    {
        var newObject = Instantiate(_boomEffect, new Vector3(10, 10, 0), Quaternion.identity) as GameObject;
        newObject.transform.SetParent(_mainCanvas.transform, false);
        newObject.transform.position = new Vector3(place.x, place.y, 0);
    }

    
}
