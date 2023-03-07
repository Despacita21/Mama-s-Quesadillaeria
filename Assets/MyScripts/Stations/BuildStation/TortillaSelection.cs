using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TortillaSelection : MonoBehaviour
{

    [SerializeField] TortillaType tortillaType;
    [SerializeField] GameObject tortillaPrefab;

    BuildStationManager buildStationManager;

    private void Start()
    {
        buildStationManager = FindObjectOfType<BuildStationManager>();
    }

    private void OnMouseDown()
    {
        buildStationManager.SelectTortilla(tortillaType, tortillaPrefab, transform);
    }

}
