using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int _score;
    // Start is called before the first frame update
    void Start()
    {
        _score = 10;
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
