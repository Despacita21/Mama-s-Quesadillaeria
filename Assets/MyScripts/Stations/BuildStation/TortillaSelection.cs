using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TortillaSelection : MonoBehaviour
{

    [SerializeField] TortillaType tortillaType;
    [SerializeField] GameObject tortillaPrefab;

    [SerializeField] Vector3 tortillaSpawnLocation;

    private void OnMouseDown()
    {
        Instantiate(tortillaPrefab, tortillaSpawnLocation, Quaternion.identity);
    }

}
