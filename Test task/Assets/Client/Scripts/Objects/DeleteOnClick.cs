using UnityEngine;
using UnityEngine.EventSystems;


public class DeleteOnClick : MonoBehaviour
{

    private SpawnManager _spawnManager;

    void Start()
    {
        _spawnManager = GameObject.Find("LevelManager").GetComponent<SpawnManager>();
    }

    public void Destroy()
    {
        _spawnManager.SpawnBoom(Input.mousePosition);
        Destroy(gameObject);
    }

    //TODO отдельный скрипт для других эффектов? генератор эффектов?
}
