using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meal : MonoBehaviour
{
    public TortillaType tortillaType;
    public CheeseType cheeseType;
    public List<ToppingType> toppingTypes = new List<ToppingType>();
    public DippingSauceType dippingSauceType;
    public ChipType chipType;
    public List<ChipToppingType> chipToppingTypes = new List<ChipToppingType>();
}
