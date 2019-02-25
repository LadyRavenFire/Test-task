using System;
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

    void Start()
    {
        MRaycaster = GetComponent<GraphicRaycaster>();
        MEventSystem = GetComponent<EventSystem>();

        _scoreManager = GameObject.Find("LevelManager").GetComponent<ScoreManager>();
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
                print("-");
                _scoreManager.AddScore(-1);
            }
            else
            {
                print("+");
                foreach (RaycastResult result in results)
                {
                    if (result.gameObject.name.Contains("SimpleBird"))
                    {
                        
                        _scoreManager.AddScore(1);
                        break;
                    }
                }
            }
        }
    }
}
