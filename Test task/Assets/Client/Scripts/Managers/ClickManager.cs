using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class ClickManager : MonoBehaviour
{
    public GraphicRaycaster MRaycaster;
    public PointerEventData MPointerEventData;
    public EventSystem MEventSystem;

    private ScoreManager _scoreManager;
    private TimeManager _timeManager;
    private SpawnManager _spawnManager;
    private ClickAudioManager _clickAudioManager;

    private Slider _streakSlider;

    private int _streak;

    void Start()
    {
        MRaycaster = GetComponent<GraphicRaycaster>();
        MEventSystem = GetComponent<EventSystem>();

        _scoreManager = GameObject.Find("LevelManager").GetComponent<ScoreManager>();
        _timeManager = GameObject.Find("LevelManager").GetComponent<TimeManager>();
        _streakSlider = GameObject.Find("StreakSlider").GetComponent<Slider>();
        _spawnManager = GameObject.Find("LevelManager").GetComponent<SpawnManager>();
        _clickAudioManager = GameObject.Find("SoundManager").GetComponent<ClickAudioManager>();

        _streak = 0;
        _streakSlider.value = _streak;
    }
   

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) //TODO переделать на axis
        {

            MPointerEventData = new PointerEventData(MEventSystem);
            MPointerEventData.position = Input.mousePosition;
            
            List<RaycastResult> results = new List<RaycastResult>();
            
            MRaycaster.Raycast(MPointerEventData, results);

            bool IsBird = false; //TODO переделать на что-то другое, сейчас костыль
            bool IsClock = false;
            bool IsButton = false;

            foreach (RaycastResult result in results)
            {
                if (result.gameObject.name.Contains("SimpleBird"))
                {
                    IsBird = true;
                    break;
                }

                if (result.gameObject.name.Contains("Clock"))
                {
                    IsClock = true;
                    break;
                }

                if (result.gameObject.name.Contains("Button"))
                {
                    IsButton = true;
                    break;
                }
            }

            if (IsBird)
            {
                _scoreManager.AddScore(1);
                _streak += 1;
                _streakSlider.value = _streak;
                _clickAudioManager.ClickOnBird();
            }

            if (IsClock)
            {
                _timeManager.AddTime(3);
                _clickAudioManager.ClickOnClock();
            }

            if (!IsClock && !IsBird && !IsButton)
            {
                _streak = 0;
                _streakSlider.value = _streak;
            }

            if (_streak == 5)
            {
                _spawnManager.SpawnClock();
                _streak = 0;
                _streakSlider.value = _streak; 
            }
            
        }
    }
}
