using UnityEngine;

public class TimeStopper : MonoBehaviour
{
    [SerializeField] private float _timeScale;
    [SerializeField] private float _howMuchStop;
    private float _stopperTime;
    private bool flag;

    void Start()
    {
        flag = false;
        _stopperTime = 0f;
    }

    void FixedUpdate()
    {
        if (_stopperTime > 0f )
        {
            _stopperTime = _stopperTime - Time.fixedDeltaTime;
            Time.timeScale = _timeScale;
        }
        else if(flag)
        {
            flag = false;
            Time.timeScale = 1f;
        }
    }

    public void TimeStopperStart()
    {
        flag = true;
        _stopperTime = 5f;
        Time.timeScale = _timeScale;
    }
}
