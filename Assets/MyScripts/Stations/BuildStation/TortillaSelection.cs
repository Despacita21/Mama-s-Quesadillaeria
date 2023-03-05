using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TortillaSelection : MonoBehaviour
{

    [SerializeField] TortillaType tortillaType;

    BuildStationManager buildStationManager;

    private void Start()
    {
        buildStationManager = FindObjectOfType<BuildStationManager>();
    }

    private void OnMouseDown()
    {
        buildStationManager.SelectTortilla(tortillaType);
    }

}
