using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tortilla : MonoBehaviour
{
    public bool selected;
    public Vector3 targetPosition;
    public float moveSpeed;

    private Order order;
    private Coroutine moveCoroutine;

    private void Start()
    {
        // Set the initial position of the object to its current position
        targetPosition = transform.position;
    }

    private void OnMouseDown()
    {
        // Check if there is already a move coroutine running
        if (moveCoroutine != null)
        {
            // Stop the previous move coroutine
            StopCoroutine(moveCoroutine);
        }

        selected = true;
        CreateOrder();

        // Start the move coroutine
        moveCoroutine = StartCoroutine(MoveToTarget());
    }

    private IEnumerator MoveToTarget()
    {
        while (selected)
        {
            // Calculate the step size based on the move speed and the elapsed time since the last frame
            float step = moveSpeed * Time.deltaTime;

            // Move the object towards the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            // Check if the object has reached the target position
            if (transform.position == targetPosition)
            {
                selected = false;
            }

            // Wait for the end of the frame before continuing the loop
            yield return new WaitForEndOfFrame();
        }
    }

    private void CreateOrder()
    {
        // Create a new order object
        order = new Order();

        // Add the tortilla to the order
        order.AddFoodItem(new FoodItem("Tortilla", 1.0f));

        // Submit the order
        order.SubmitOrder();
    }
}