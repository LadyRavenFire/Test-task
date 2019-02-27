using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lose : MonoBehaviour
{

    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _loseMenuPanel;
    [SerializeField] private TextMeshProUGUI _yourScoreText;
    [SerializeField] private TextMeshProUGUI _bestScoreText;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Button _retryButton;

    public ScoreManager _scoreManager;
    public TimeManager _timeManager;

    void Start()
    {

        _retryButton.onClick.AddListener(Retry);
        _mainMenuButton.onClick.AddListener(MainMenu);

        _losePanel.SetActive(false);
    }

    public void LoseGame(int score)
    {       
        Time.timeScale = 0f;
        DeleteObjects();
        _losePanel.SetActive(true);
        _losePanel.transform.SetAsLastSibling();
        _yourScoreText.text = "Your score: " + score;
        if (PlayerPrefs.GetInt("BestScore") < score)
        {
            PlayerPrefs.SetInt("BestScore", score);
        }
        _bestScoreText.text = "Best score: " + PlayerPrefs.GetInt("BestScore");
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

    void Retry()
    {
        DeleteObjects();

        _scoreManager.SetStartScore();
        _timeManager.SetStartTime();

        Time.timeScale = 1f;

        _losePanel.SetActive(false);
    }

    void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public bool IsActive()
    {
        return _losePanel.activeSelf;
    }
    
}
