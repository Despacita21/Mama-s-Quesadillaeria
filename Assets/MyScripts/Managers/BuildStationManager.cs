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

    public void Update()
    {
        switch (buildState) 
        {
            case BuildState.SelectTortilla:
                break;
            case BuildState.SelectCheese:
                break;
            case BuildState.SelectToppings:
                break;
            default:
                break;
        }
    }


    public void SelectTortilla(TortillaType selectedTortilla, GameObject tortillaPrefab, Transform tortillaTransform)
    {
        GameObject tortillaInstance = Instantiate(tortillaPrefab, tortillaTransform.position, Quaternion.identity);

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
