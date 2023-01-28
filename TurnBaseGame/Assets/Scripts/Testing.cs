using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{

    [SerializeField] Transform gridDebugObjectPrefab;
    GridSystem gridSystem;
    void Start()
    {
        gridSystem = new GridSystem(10, 10, 2);
        gridSystem.CreateDebugPrefeb(gridDebugObjectPrefab);
        
        Debug.Log(new GridPosition(5,7));
    }

    private void Update()
    {
        //Debug.Log(gridSystem.GetGridPosition(MouseWorld.GetPosition()));
    }

}