using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemGenerator : MonoBehaviour
{
    public GameObject Prefab;
    public float Delay;
    private float TempTime = 0;
    private GlobalTime timer => transform.parent.GetComponent<GlobalTime>();  

    void Update()
    {
        TempTime += Time.deltaTime;   
        if(TempTime >= Delay)
        {
            SpawnBonus();
        }
    }

    public void SpawnBonus()
    {
        TempTime = 0;
        Instantiate(Prefab);
    }
}
