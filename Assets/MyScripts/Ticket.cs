using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Ticket : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    [SerializeField] public TicketSnapping currentSnapPosition;
    [HideInInspector] public bool foundNewSnapPosition;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        rectTransform.position = eventData.position + (Vector2)rectTransform.localScale / 2;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.localScale = Vector3.Lerp(rectTransform.localScale, new Vector3(0.25f, 0.25f, 0.25f), 0.2f);
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        rectTransform.localScale = new Vector3(currentSnapPosition.scaleFactor, currentSnapPosition.scaleFactor, currentSnapPosition.scaleFactor);

        if (foundNewSnapPosition)
        {
            foundNewSnapPosition = false;
            return;
        }

        rectTransform.anchoredPosition = currentSnapPosition.GetComponent<RectTransform>().anchoredPosition;
    }

}
