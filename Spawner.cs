using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Donut> _donutes = new List<Donut>();
    [SerializeField] private Cylinder _cylinder;
    [SerializeField] private Lane _lane;

    private int _randomIndexDonutes;
    private int _randomCountDonutes;

    private Cylinder Cylinder;

    private int GetRandomIndexDonut()
    {
        return _randomIndexDonutes = UnityEngine.Random.Range(0, _donutes.Count);
    }

    private void GetRandomCountDonut()
    {
        _randomCountDonutes = UnityEngine.Random.Range(1, 3);
    }

    public Cylinder InstantiateCylinder(Vector3 position)
    {
        return Cylinder = Instantiate(_cylinder, position, Quaternion.identity);
    }

    public void InstantiateDonutes()
    {
        float extraValue = -0.2f;   
        GetRandomCountDonut();

        for (int i = 0; i < _donutes.Count; i++)
        {
            if(i > _randomCountDonutes)
            {
                break;
            }
            else
            {
                Donut donut = Instantiate(_donutes[GetRandomIndexDonut()], new Vector3(Cylinder.transform.position.x, Cylinder.transform.position.y + extraValue, Cylinder.transform.position.z), Quaternion.identity);
                donut.transform.parent = Cylinder.transform;
                Cylinder.AddDonutes(donut);
                extraValue += 0.2f;
            }
        }              
    }  
}
