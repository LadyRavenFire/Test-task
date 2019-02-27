using UnityEngine;

public class TimeStopper : MonoBehaviour
{
    [SerializeField] private float _timeScale;
    [SerializeField] private float _howMuchStop;
    private float _stopperTime;
    private bool _onOffFlag;

    void Start()
    {
       Clear();
    }

    void FixedUpdate()
    {
        if (_stopperTime > 0f )
        {
            _stopperTime = _stopperTime - Time.fixedDeltaTime;
            Time.timeScale = _timeScale;
        }
        else if(_onOffFlag)
        {
            _onOffFlag = false;
            Time.timeScale = 1f;
        }
    }

    public void Clear()
    {
        _onOffFlag = false;
        _stopperTime = 0f;
    }

    public void TimeStopperStart()
    {
        _onOffFlag = true;
        _stopperTime = 5f;
        Time.timeScale = _timeScale;
    }
}
