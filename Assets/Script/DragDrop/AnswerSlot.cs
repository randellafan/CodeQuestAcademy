using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnswerSlot : MonoBehaviour,IDropHandler
{
    public void OnDrop(PointerEventData eventData){
        Debug.Log("OnDrop");
        if (eventData.pointerDrag !=null){
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }
    }
}
