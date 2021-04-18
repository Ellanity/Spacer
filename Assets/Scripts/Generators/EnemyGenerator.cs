﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public List<GameObject> Prefab;
    public AnimationCurve Delay;
    private float TempTime = 0;
    private GlobalTime timer => transform.parent.GetComponent<GlobalTime>();  
    //private float 

    void Update()
    {
        SpawnEnemy();
        TempTime += Time.deltaTime;
    }

    void SpawnEnemy()
    {
        if(TempTime >= Delay.Evaluate(timer.time))
        {
            TempTime = 0;
            Instantiate(Prefab[Random.Range(0, Prefab.Count)]);
        }
    }
}
