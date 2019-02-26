using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int _score;
    [SerializeField] private Text _scoreText;

    private Lose _lose;

    void Start()
    {
        _score = 10;
        _lose = GameObject.Find("LevelManager").GetComponent<Lose>();
    }

    void OnGUI()
    {
        _scoreText.text = "Score: " + _score;
    }

    void Update() //TODO переделать
    {
        if (_score < 0)
        {
            _lose.LoseGame(_score);
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
