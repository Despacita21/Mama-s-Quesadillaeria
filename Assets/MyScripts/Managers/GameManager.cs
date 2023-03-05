using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singlton Pattern
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    //Unlocked Ingredient Types
    public int tortillaTypesUnlocked;
    public int cheeseTypesUnlocked;
    public int toppingTypesUnlocked;
    public int dippingSauceTypesUnlocked;
    public int chipTypesUnlocked;
    public int chipToppingTypesUnlocked;

}
