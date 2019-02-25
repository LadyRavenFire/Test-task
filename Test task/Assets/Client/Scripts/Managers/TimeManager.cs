using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float _time;
    [SerializeField] private Text _timeText;

    void Start()
    {
        _time = 30f;
    }

    void FixedUpdate()
    {
        _time = _time - Time.deltaTime;
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
}
