using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int _score;
    [SerializeField] private Text _scoreText;

    void Start()
    {
        _score = 10;
    }

    void OnGUI()
    {
        _scoreText.text = "Score: " + _score;
    }

    void Update() //TODO переделать
    {
        if (_score < 0)
        {
            Application.Quit();
        }
    }
    public int Output()
    {
        return _score;
    }

    public void AddScore(int enter)
    {
        _score += enter;
    }

   
}
