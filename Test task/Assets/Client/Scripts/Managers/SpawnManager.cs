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
    
    public Random Random;

    private float _delay;


    void Start()
    {
        _scoreManager = GameObject.Find("LevelManager").GetComponent<ScoreManager>();
        Random = new Random();
        _delay = Random.Next(0,3);
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
                if (Random.Next(0, 4) == 0)
                {
                    SpawnStaticObject(_ghost, 0.3f);
                }
            }
            else if(score>=30)
            {
                if (Random.Next(0, 4) == 0)
                {
                    SpawnLeftRightMovingObject(_simpleBird, (int)(Screen.height * 0.13f));
                }
                if (Random.Next(0, 3) == 0)
                {
                    SpawnStaticObject(_ghost, 0.3f);
                }
                SpawnLeftRightMovingObject(_gourgule, (int)(Screen.height * 0.15f));
            }

            if (Random.Next(0, 10) == 0)
            {
                SpawnStaticObject(_moreTime, 0.1f); 
            }

            if (Random.Next(0, 50)==0)     
            {
                SpawnStaticObject(_timeStopper, 0.1f);
            }
        }
    }

    void SpawnLeftRightMovingObject(GameObject Object, int BorderOfScreen)
    {
        _delay = Random.Next(0, 3);
        int leftRight = Random.Next(0, 2);
        int borderOfScreen = BorderOfScreen; 

        int yCoord = (int)Random.Next(0 + borderOfScreen, Screen.height - borderOfScreen);
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

    public void SpawnStaticObject(GameObject Object, float border)
    {
        var newObject = Instantiate(Object, new Vector3(10, 10, 0), Quaternion.identity) as GameObject;
        newObject.transform.SetParent(_mainCanvas.transform, false);
        newObject.transform.position = new Vector3(
            Random.Next((int)(Screen.width * border), Screen.width - (int)(Screen.width * border)),
            Random.Next((int)(Screen.height * border), Screen.height - (int)(Screen.height * border)),
            0);
    }

    public void SpawnClock()
    {
        var newObject = Instantiate(_clock, new Vector3(10, 10, 0), Quaternion.identity) as GameObject;
        newObject.transform.SetParent(_mainCanvas.transform, false);
        newObject.transform.position = new Vector3(
            Random.Next((int)(Screen.width * 0.1f), Screen.width-(int)(Screen.width*0.1f)),
            Random.Next((int)(Screen.height*0.1f), Screen.height-(int)(Screen.height * 0.1f)), 
            0);
    }
    
}
