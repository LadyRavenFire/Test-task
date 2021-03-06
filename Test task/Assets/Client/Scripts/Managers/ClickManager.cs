﻿using UnityEngine;
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
    private PauseMenu _pauseMenu;

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
        _pauseMenu = GameObject.Find("LevelManager").GetComponent<PauseMenu>();

        _streak = 0;
        _streakSlider.value = _streak;
    }
   

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !_pauseMenu._pauseMenuPanel.activeSelf)
        {

            MPointerEventData = new PointerEventData(MEventSystem);
            MPointerEventData.position = Input.mousePosition;
            
            List<RaycastResult> results = new List<RaycastResult>();
            
            MRaycaster.Raycast(MPointerEventData, results);

            bool IsOnClicable = false;

            if (Time.timeScale == 0f)
            {
                IsOnClicable = true;
            }

            foreach (RaycastResult result in results)
            {
                if (result.gameObject.name.Contains("SimpleBird"))
                {
                    result.gameObject.GetComponent<DeleteOnClick>().Destroy();
                    _scoreManager.AddScore(1);
                    _streak += 1;
                    _streakSlider.value = _streak;
                    _clickAudioManager.ClickOnBird();
                    IsOnClicable = true;
                    break;
                }
               

                if (result.gameObject.name.Contains("Clock"))
                {
                    result.gameObject.GetComponent<DeleteOnClick>().Destroy();
                    _timeManager.AddTime(3);
                    _clickAudioManager.ClickOnClock();
                    IsOnClicable = true;
                    break;
                }

                if (result.gameObject.name.Contains("MoreTime"))
                {
                    result.gameObject.GetComponent<DeleteOnClick>().Destroy();
                    _timeManager.AddTime(2);
                    _clickAudioManager.ClickOnClock();
                    IsOnClicable = true;    
                    break;
                }

                if (result.gameObject.name.Contains("TimeStopper"))
                {
                    result.gameObject.GetComponent<DeleteOnClick>().Destroy();
                    GameObject.Find("LevelManager").GetComponent<TimeStopper>().TimeStopperStart();
                    _clickAudioManager.ClickOnClock();
                    IsOnClicable = true;
                    break;
                }

                if (result.gameObject.name.Contains("Gourgule"))
                {
                    result.gameObject.GetComponent<DeleteOnClick>().Destroy();
                    _scoreManager.AddScore(2);
                    _streak += 1;
                    _streakSlider.value = _streak;
                    _clickAudioManager.ClickOnBird();
                    IsOnClicable = true;
                    break;
                }

                if (result.gameObject.name.Contains("Button"))
                {
                    IsOnClicable = true;
                    break;
                }

                if (result.gameObject.name.Contains("Ghost"))
                {
                    Lose _lose = GameObject.Find("LevelManager").GetComponent<Lose>();
                    _lose.LoseGame(_scoreManager.Output());
                }
            }

            if (!IsOnClicable)
            {
                DeleteStreak();
            }

            if (_streak == 5)
            {
                _spawnManager.SpawnClock();
                DeleteStreak();
            }
            
        }
    }

    public void DeleteStreak()
    {
        _streak = 0;
        _streakSlider.value = _streak;
    }
}
