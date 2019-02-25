using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class ClickManager : MonoBehaviour
{
    public GraphicRaycaster MRaycaster;
    public PointerEventData MPointerEventData;
    public EventSystem MEventSystem;

    private ScoreManager _scoreManager;
    private TimeManager _timeManager;

    private Slider _streakSlider;

    private int _streak;

    void Start()
    {
        MRaycaster = GetComponent<GraphicRaycaster>();
        MEventSystem = GetComponent<EventSystem>();

        _scoreManager = GameObject.Find("LevelManager").GetComponent<ScoreManager>();
        _timeManager = GameObject.Find("LevelManager").GetComponent<TimeManager>();
        _streakSlider = GameObject.Find("StreakSlider").GetComponent<Slider>();

        _streak = 0;
        _streakSlider.value = _streak;
    }
   

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            MPointerEventData = new PointerEventData(MEventSystem);
            MPointerEventData.position = Input.mousePosition;
            
            List<RaycastResult> results = new List<RaycastResult>();
            
            MRaycaster.Raycast(MPointerEventData, results);           

            if (results.Count == 0)
            {
                _streak = 0;
                _streakSlider.value = _streak;
            }
            else
            {
                //print("+");
                foreach (RaycastResult result in results)
                {
                    if (result.gameObject.name.Contains("SimpleBird"))
                    {
                        _scoreManager.AddScore(1);
                        _streak += 1;
                        _streakSlider.value = _streak;
                        break;
                    }
                }

                if (_streak == 5)
                {
                    _timeManager.AddTime(10);
                    _streak = 0;
                    _streakSlider.value = _streak;
                }
            }
        }
    }
}
