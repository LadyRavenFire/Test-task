using UnityEngine;
using UnityEngine.EventSystems;


public class DeleteOnClick : MonoBehaviour,  IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Destroy(gameObject);
    }
}
