using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float _time;
    // Start is called before the first frame update
    void Start()
    {
        _time = 60f;
    }

    void FixedUpdate()
    {
        _time = _time - Time.deltaTime;
    }

    public float Output()
    {
        return _time;
    }

    public void AddScore(float enter)
    {
        _time += enter;
    }
}
