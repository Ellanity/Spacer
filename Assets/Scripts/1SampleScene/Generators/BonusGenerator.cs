﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusGenerator : MonoBehaviour
{
    public List<GameObject> Prefab;
    public float Delay;
    private float TempTime = 0;
    private GlobalTime timer => transform.parent.GetComponent<GlobalTime>();  

    void Update()
    {
        SpawnBonus();
        TempTime += Time.deltaTime;
    }

    void SpawnBonus()
    {
        if(TempTime >= Delay)
        {
            TempTime = 0;
            Delay = Random.Range(10f,20f);
            Instantiate(Prefab[Random.Range(0, Prefab.Count)]);
        }
    }
}