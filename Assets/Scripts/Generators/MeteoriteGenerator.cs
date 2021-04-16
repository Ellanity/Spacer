﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteGenerator : MonoBehaviour
{
    public List<GameObject> Prefab;
    public AnimationCurve Delay;
    private float TempTime = 0;
    private GlobalTime timer => transform.parent.GetComponent<GlobalTime>();  
    //private float 

    void Update()
    {
        SpawnMeteorite();
        TempTime += Time.deltaTime;
    }

    void SpawnMeteorite()
    {
        if(TempTime >= Delay.Evaluate(timer.time))
        {
            TempTime = 0;
            GameObject NewMeteorite = Instantiate(Prefab[Random.Range(0, Prefab.Count)]);
        }
    }
}
