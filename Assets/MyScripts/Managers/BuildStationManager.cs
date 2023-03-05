using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildStationManager : MonoBehaviour
{
    
    enum BuildState
    {
        SelectTortilla,
        SelectCheese,
        PourCheese,
        SelectToppings
    }
    private BuildState buildState;

    [Header("Tortilla Variables")]
    [SerializeField] GameObject flourTortilla, cornTortilla;

    public void SelectTortilla(TortillaType selectedTortilla)
    {
        buildState = BuildState.SelectCheese;
    }

    public void SelectCheese()
    {
        buildState = BuildState.PourCheese;
    }

    public void PourCheese()
    {
        buildState = BuildState.SelectToppings;
    }

}
