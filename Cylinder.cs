using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cylinder : MonoBehaviour
{
    [SerializeField]  List<Donut> _donutes = new List<Donut>();
    public int maxCountDonutesOnCylinder { get; private set; } = 3;
    public event Action Matched;

    private void OnEnable()
    {
        Matched += DestroyCylinder;
    }

    private void OnDisable()
    {
        Matched -= DestroyCylinder;
    }

    private void DestroyCylinder()
    {
        Destroy(gameObject);
    }


    private void FixedUpdate()
    {
        for (int i = 0; i < _donutes.Count; i++)
        {
            for (int j = 0; i < _donutes.Count; i++)
            {
                for (int x = 0; i < _donutes.Count; i++)
                {
                    try
                    {
                        if (_donutes[i].Color == _donutes[j + 1].Color && _donutes[i].Color == _donutes[x + 2].Color)
                        {
                            Matched?.Invoke();
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }
    }

    public void AddDonutes(Donut donut)
    {
        _donutes.Add(donut);
    }

    public int GetDonutesCount()
    {
        return _donutes.Count;
    }
}
