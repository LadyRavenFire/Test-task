using UnityEngine;
using Random = System.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _simpleBird;
    [SerializeField] private GameObject _boomEffect;
    [SerializeField] private GameObject _clock;
    [SerializeField] private GameObject _gourgule;
    [SerializeField] private GameObject _ghost;
    [SerializeField] private GameObject _moreTime;
    [SerializeField] private GameObject _timeStopper;

    private ScoreManager _scoreManager;


    [SerializeField] private Canvas _mainCanvas;
    
    private Random _random;

    private float _delay;


    void Start()
    {
        _scoreManager = GameObject.Find("LevelManager").GetComponent<ScoreManager>();
        _random = new Random();
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
            int score = _scoreManager.Output();

            if (score<20)
            {
                SpawnLeftRightMovingObject(_simpleBird, (int)(Screen.height * 0.12f));
            }
            else if (score<30 && score >=20)
            {
                SpawnLeftRightMovingObject(_simpleBird, (int)(Screen.height * 0.12f));
                if (_random.Next(0, 4) == 0)
                {
                    SpawnGhost();
                }
            }
            else if(score>=30)
            {
                if (_random.Next(0, 4) == 0)
                {
                    SpawnLeftRightMovingObject(_simpleBird, (int)(Screen.height * 0.12f));
                }
                if (_random.Next(0, 3) == 0)
                {
                    SpawnGhost();
                }
                SpawnLeftRightMovingObject(_gourgule, (int)(Screen.height * 0.15f));
            }

            if (_random.Next(0, 10) == 0)
            {
                SpawnMoreTime();
            }

            if (_random.Next(0, 50)==0)     
            {
                SpawnTimeStopper();
            }
        }
    }

    void SpawnLeftRightMovingObject(GameObject Object, int BorderOfScreen)
    {
        _delay = _random.Next(0, 3);
        int leftRight = _random.Next(0, 2);
        int borderOfScreen = BorderOfScreen; //TODO калибровать значения

        int yCoord = (int)_random.Next(0 + borderOfScreen, Screen.height - borderOfScreen); //TODO ScreenWidthm, ScreenHeight.
        var newObject = Instantiate(Object, new Vector3(10, 10, 0), Quaternion.identity) as GameObject;
        newObject.transform.SetParent(_mainCanvas.transform, false);

        if (leftRight == 0)
        {
            newObject.transform.position = new Vector3(Screen.width + (Screen.width * 0.1f), yCoord, 0);
        }
        else
        {
            newObject.transform.position = new Vector3(-(Screen.width * 0.1f), yCoord, 0);
            IsLeftMoving IsLeftMoving = newObject.GetComponent<IsLeftMoving>();
            IsLeftMoving.IsLeft = false;
        }
    }

    public void SpawnBoom(Vector3 place)
    {
        var newObject = Instantiate(_boomEffect, new Vector3(10, 10, 0), Quaternion.identity) as GameObject;
        newObject.transform.SetParent(_mainCanvas.transform, false);
        newObject.transform.position = new Vector3(place.x, place.y, 0);
    }

    public void SpawnClock() //TODO рефаторнуть и свернуть в одну функцию все ниже
    {
        var newObject = Instantiate(_clock, new Vector3(10, 10, 0), Quaternion.identity) as GameObject;
        newObject.transform.SetParent(_mainCanvas.transform, false);
        newObject.transform.position = new Vector3(
            _random.Next((int)(Screen.width * 0.1f), Screen.width-(int)(Screen.width*0.1f)),
            _random.Next((int)(Screen.height*0.1f), Screen.height-(int)(Screen.height * 0.1f)), 
            0);
    }

    public void SpawnGhost()
    {
        var newObject = Instantiate(_ghost, new Vector3(10, 10, 0), Quaternion.identity) as GameObject;
        newObject.transform.SetParent(_mainCanvas.transform, false);
        newObject.transform.position = new Vector3(
            _random.Next((int)(Screen.width * 0.3f), Screen.width - (int)(Screen.width * 0.3f)),
            _random.Next((int)(Screen.height * 0.3f), Screen.height - (int)(Screen.height * 0.3f)),
            0);
    }

    public void SpawnTimeStopper()
    {
        var newObject = Instantiate(_timeStopper, new Vector3(10, 10, 0), Quaternion.identity) as GameObject;
        newObject.transform.SetParent(_mainCanvas.transform, false);
        newObject.transform.position = new Vector3(
            _random.Next((int)(Screen.width * 0.1f), Screen.width - (int)(Screen.width * 0.1f)),
            _random.Next((int)(Screen.height * 0.1f), Screen.height - (int)(Screen.height * 0.1f)),
            0);
    }

    public void SpawnMoreTime()
    {
        var newObject = Instantiate(_moreTime, new Vector3(10, 10, 0), Quaternion.identity) as GameObject;
        newObject.transform.SetParent(_mainCanvas.transform, false);
        newObject.transform.position = new Vector3(
            _random.Next((int)(Screen.width * 0.1f), Screen.width - (int)(Screen.width * 0.1f)),
            _random.Next((int)(Screen.height * 0.1f), Screen.height - (int)(Screen.height * 0.1f)),
            0);
    }
   
    
}
