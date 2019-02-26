using UnityEngine;
using UnityEngine.EventSystems;


public class DeleteOnClick : MonoBehaviour,  IPointerClickHandler
{

    private SpawnManager _spawnManager;

    void Start()
    {

        _spawnManager = GameObject.Find("LevelManager").GetComponent<SpawnManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //TODO красивый эффект на взрыв

        _spawnManager.SpawnBoom(Input.mousePosition);
        Destroy(gameObject);
    }
}
