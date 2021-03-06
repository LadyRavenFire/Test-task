﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Button _pauseMenuButton;

    public GameObject _pauseMenuPanel;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Button _retryButton;
    [SerializeField] private Button _resumeButton;


    public ScoreManager _scoreManager;
    public TimeManager _timeManager;
    public Lose _Lose;

    void Start()
    {

        _pauseMenuButton.onClick.AddListener(PressPauseMenu);
        _resumeButton.onClick.AddListener(Resume);
        _retryButton.onClick.AddListener(Retry);
        _mainMenuButton.onClick.AddListener(MainMenu);
        

        _pauseMenuPanel.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (_pauseMenuPanel.activeSelf == false && !_Lose.IsActive())
            {
                OpenPauseMenu();
            }
            else
            {
                if (!_Lose.IsActive())
                {
                    Resume();
                }
            }
        }
    }

    void PressPauseMenu()
    {
        if (_pauseMenuPanel.activeSelf == false)
        {
            OpenPauseMenu();
        }
        else
        {
            Resume();
        }
    }

    void OpenPauseMenu()
    {
        Time.timeScale = 0f;
        _pauseMenuPanel.SetActive(true);
        _pauseMenuPanel.transform.SetAsLastSibling();
    }

    void Resume()
    {
        Time.timeScale = 1f;
        _pauseMenuPanel.SetActive(false);
    }

    void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    void Retry() 
    {
        DeleteObjects();
        _scoreManager.SetStartScore();
        _timeManager.SetStartTime();

        Resume();
    }

    void DeleteObjects()
    {
        var objects = GameObject.FindGameObjectsWithTag("Deletable");
        GameObject.Find("MainCanvas").GetComponent<ClickManager>().DeleteStreak();
        GameObject.Find("LevelManager").GetComponent<TimeStopper>().Clear();

        foreach (var objective in objects)
        {
            Destroy(objective);
        }
    }

}
