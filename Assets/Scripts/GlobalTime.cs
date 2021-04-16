using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalTime : MonoBehaviour
{

    public float time = 0f;
    void Update()
    {
        time += Time.deltaTime;
    }
}
