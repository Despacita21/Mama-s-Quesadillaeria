/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    public List<FoodItem> foodItems;
    public int orderNumber;

    // Add a food item to the order
    public void AddFoodItem(FoodItem foodItem)
    {
        foodItems.Add(foodItem);
    }

    // Remove a food item from the order
    public void RemoveFoodItem(FoodItem foodItem)
    {
        foodItems.Remove(foodItem);
    }
    
    // Submit the order
    public void SubmitOrder()
    {
        // Send the order to the kitchen or a server to prepare the food
        Debug.Log("Submitting order #" + orderNumber + " with " + foodItems.Count + " food items.");
    }
}*/














using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order
{
    public int OrderNumber;

    public TortillaType tortillaType;
    public CheeseType cheeseType;
    public ToppingType[] toppings = new ToppingType[4];
    public DippingSauceType dippingSauceType;
    public ChipType chipType;
    public ChipToppingType[] chipToppings = new ChipToppingType[3];


    public Order()
    {
        tortillaType = (TortillaType)Random.Range(0, GameManager.instance.tortillaTypesUnlocked);
        cheeseType = (CheeseType)Random.Range(0, GameManager.instance.cheeseTypesUnlocked);

        for (int i = 0; i < toppings.Length; i++)
        {
            if(i == 0)
            {
                toppings[i] = (ToppingType)Random.Range(1, GameManager.instance.toppingTypesUnlocked);
            }
            if(i > 0)
            {
                if (toppings[i-1] == ToppingType.NONE)
                {
                    toppings[i] = ToppingType.NONE;
                }
                else
                {
                    toppings[i] = (ToppingType)Random.Range(0, GameManager.instance.toppingTypesUnlocked);
                }
            }
        }

        dippingSauceType = (DippingSauceType)Random.Range(0, GameManager.instance.dippingSauceTypesUnlocked);
        chipType = (ChipType)Random.Range(0, GameManager.instance.chipTypesUnlocked);

        for (int i = 0; i < chipToppings.Length; i++)
        {
            if (i == 0)
            {
                chipToppings[i] = (ChipToppingType)Random.Range(1, GameManager.instance.chipToppingTypesUnlocked);
            }
            if (i > 0)
            {
                if (chipToppings[i - 1] == ChipToppingType.NONE)
                {
                    chipToppings[i] = ChipToppingType.NONE;
                }
                else
                {
                    chipToppings[i] = (ChipToppingType)Random.Range(0, GameManager.instance.chipToppingTypesUnlocked);
                }
            }
        }
    }

}
