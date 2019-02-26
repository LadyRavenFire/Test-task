using UnityEngine;
using UnityEngine.UI;

public class Lose : MonoBehaviour
{

    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _loseMenuPanel;
    [SerializeField] private Text _yourScoreText;
    [SerializeField] private Text _bestScoreText;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Button _retryButton;
   
    void Start()
    {
        _losePanel.SetActive(false);
    }

    public void LoseGame(int score)
    {       
        Time.timeScale = 0f;
        DeleteObjects();
        _losePanel.SetActive(true);
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

        foreach (var objective in objects)
        {
            Destroy(objective);
        }
    }
    
}
