using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildStationManager : MonoBehaviour
{
    
    enum BuildState
    {
        Tortilla,
        Cheese,
        Toppings
    }
    private BuildState buildState;

    [Header("Tortilla Variables")]
    [SerializeField] GameObject flourTortilla, cornTortilla;

    public void SelectTortilla(TortillaType selectedTortilla)
    {

    }

}
