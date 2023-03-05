using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Ticket : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    [SerializeField] public TicketSnapping currentSnapPosition;
    [HideInInspector] public bool foundNewSnapPosition;

    //THIS IS ALL FOR DEBUGGING PURPOSES
    [SerializeField] TMP_Text tortillaLabel;
    [SerializeField] TMP_Text cheeseLabel;
    [SerializeField] TMP_Text topping1Label;
    [SerializeField] TMP_Text topping2Label;
    [SerializeField] TMP_Text topping3Label;
    [SerializeField] TMP_Text topping4Label;
    [SerializeField] TMP_Text dippingSauceLabel;
    [SerializeField] TMP_Text chipLabel;
    [SerializeField] TMP_Text chipTopping1Label;
    [SerializeField] TMP_Text chipTopping2Label;
    [SerializeField] TMP_Text chipTopping3Label;
    //THIS IS WHERE THE DEBUGGING PART ENDS

    public void CreateTicket(Order order)
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        currentSnapPosition = canvas.transform.Find("Ticket Holder").Find("Ticket Holder Snap").GetComponent<TicketSnapping>();

        tortillaLabel.text = order.tortillaType.ToString();
        cheeseLabel.text = order.cheeseType.ToString();
        topping1Label.text = order.toppings[0].ToString();
        topping2Label.text = order.toppings[1].ToString();
        topping3Label.text = order.toppings[2].ToString();
        topping4Label.text = order.toppings[3].ToString();
        dippingSauceLabel.text = order.dippingSauceType.ToString();
        chipLabel.text = order.chipType.ToString();
        chipTopping1Label.text = order.chipToppings[0].ToString();
        chipTopping2Label.text = order.chipToppings[1].ToString();
        chipTopping3Label.text = order.chipToppings[2].ToString();
    }


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
