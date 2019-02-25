using UnityEngine;

public class CheckForOutOfScreen : MonoBehaviour
{
    private CornerCoordinates _cornerCoordinates;
    private ScoreManager _scoreManager;

    private float _startCheckDelay;

    void Start()
    {
        _cornerCoordinates = GameObject.Find("MainCanvas").GetComponent<CornerCoordinates>();
        _scoreManager = GameObject.Find("LevelManager").GetComponent<ScoreManager>();

        _startCheckDelay = 2f;
    }
  
    void FixedUpdate()
    {
        if (_startCheckDelay > 0)
        {
            _startCheckDelay = _startCheckDelay - Time.deltaTime;
        }
        else
        {
            if (gameObject.transform.position.x < _cornerCoordinates.ScreenSpaceCorners[0].x)
            {
                _scoreManager.AddScore(-1);
                Destroy(gameObject);
            }

            if (gameObject.transform.position.x > _cornerCoordinates.ScreenSpaceCorners[3].x)
            {
                _scoreManager.AddScore(-1);
                Destroy(gameObject);
            }
        } 
    }
}
