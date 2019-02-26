using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Button _pauseMenuButton;

    [SerializeField] private GameObject _pauseMenuPanel;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Button _retryButton;
    [SerializeField] private Button _resumeButton;


    public ScoreManager _scoreManager;
    public TimeManager _timeManager;

    void Start()
    {

        _pauseMenuButton.onClick.AddListener(OpenPauseMenu);
        _resumeButton.onClick.AddListener(Resume);
        _retryButton.onClick.AddListener(Retry);
        _mainMenuButton.onClick.AddListener(MainMenu);
        

        _pauseMenuPanel.SetActive(false);
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

        foreach (var objective in objects)
        {
            Destroy(objective);
        }
    }

}
