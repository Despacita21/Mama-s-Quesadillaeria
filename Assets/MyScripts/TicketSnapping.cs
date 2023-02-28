using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TicketSnapping : MonoBehaviour, IDropHandler
{

    public float scaleFactor;

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            RectTransform rectTransform = eventData.pointerDrag.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

            Ticket ticket = eventData.pointerDrag.GetComponent<Ticket>();
            ticket.currentSnapPosition = this;
            ticket.foundNewSnapPosition = true;
        }
    }
}
