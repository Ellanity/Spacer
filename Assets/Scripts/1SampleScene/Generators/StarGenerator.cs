using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour
{
    public List<GameObject> Prefab;
    public float Delay;
    private float TempTime = 0;
    private GlobalTime timer => transform.parent.GetComponent<GlobalTime>();  
    //private float 

    void Update()
    {
        SpawnStar();
        TempTime += Time.deltaTime;
    }

    void SpawnStar()
    {
        if(TempTime >= Delay)
        {
            TempTime = 0;
            Instantiate(Prefab[Random.Range(0, Prefab.Count)]);
        }
    }
}
