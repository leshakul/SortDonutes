using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Lane _lane;

    private void OnMouseDown()
    {
        _lane.IntantiatePrefab();
        _lane.CheckNullSpawnPoint();
    }


}
