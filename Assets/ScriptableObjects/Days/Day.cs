using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Day", menuName = "ScriptableObjects/Day")]
public class Day : ScriptableObject
{
    [Header("Variables for the current day")]
    public int dayNumber;
    public Customer[] customers;
    public float minRateOfCustomers;
    public float maxRateOfCustomers;

    [Header("Unlockables for the next day")]
    public string[] newItemsUnlocked;
    public string[] newCustomersUnlocked;
}
