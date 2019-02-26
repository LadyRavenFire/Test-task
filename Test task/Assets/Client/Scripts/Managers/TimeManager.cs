using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float _time;
    [SerializeField] private Text _timeText;

    private ScoreManager _scoreManager;
    private Lose _lose;

    void Start()
    {
        SetStartTime();
        _lose = GameObject.Find("LevelManager").GetComponent<Lose>();
        _scoreManager = GameObject.Find("LevelManager").GetComponent<ScoreManager>();
    }

    void FixedUpdate()
    {
        _time = _time - Time.deltaTime;

        if (_time < 0)
        {
            _lose.LoseGame(_scoreManager.Output());
        }   
    }

    void OnGUI()
    {
        _timeText.text = "Time left: " + (int)_time;
    }

    public float Output()
    {
        return _time;
    }

    public void AddTime(float enter)
    {
        _time += enter;
    }

    public void SetStartTime()
    {
        _time = 30f;
    }
}
