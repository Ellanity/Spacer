using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public float TempTime;

    void Update()
    {
        TempTime += Time.deltaTime;
        if(TempTime > 3)
            SetInactive();
    }
    void SetInactive()
    {
        gameObject.SetActive(false);
    }
}
