using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Lane : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] _spawnPoints;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private List<Cylinder> _cylinders;  

    public void IntantiatePrefab()
    {
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            if (_spawnPoints[i].IsEmpty == true)
            {
                Cylinder cylinder = _spawner.InstantiateCylinder(_spawnPoints[i].transform.position);
                _spawner.InstantiateDonutes();
                _spawnPoints[i].IsEmpty = false;
                _cylinders.Add(cylinder);
                break;
            }
            else
            {
                continue;
            }
        }
    }

    public void CheckNullSpawnPoint()
    {
        for (int i = 0; i < _cylinders.Count; i++)
        {
            if (_cylinders[i] == null)
            {
                try
                {
                    if (i == 0)
                    {
                        _cylinders[i] = _cylinders[i + 1];
                        _cylinders[i + 1].transform.position = _spawnPoints[i].transform.position;
                        _cylinders[i + 1] = _cylinders[i + 2];
                        _cylinders[i + 2].transform.position = _spawnPoints[i + 1].transform.position;
                    }
                    else if(i == 1)
                    {
                        _cylinders[i] = _cylinders[i + 1];
                        _cylinders[i + 1].transform.position = _spawnPoints[i].transform.position;
                    }
                    else
                    {
                        _spawnPoints[i].IsEmpty = true;
                        _cylinders[i] = _spawner.InstantiateCylinder(_spawnPoints[i].transform.position);
                        _spawner.InstantiateDonutes();
                        _spawnPoints[i].IsEmpty = false;
                    }
                }
                catch
                {
                }
            }
        }
    }
}
