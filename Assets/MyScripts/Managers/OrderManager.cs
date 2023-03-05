using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{

    public List<Order> orders = new List<Order>();
    public List<Meal> meals = new List<Meal>();


    [Header("Ticket Creation")]
    [SerializeField] GameObject ticketPrefab;
    [SerializeField] Transform ticketParent;

    public void CreateOrder()
    {
        Order order = new Order();
        orders.Add(order);
        
        GameObject ticketInstance = Instantiate(ticketPrefab, ticketParent);
        ticketInstance.GetComponent<Ticket>().CreateTicket(order);
    }


    public void CompleteOrder(Meal finishedMeal, Order finishedOrder)
    {
        
    }

}
