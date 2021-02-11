using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Angle : MonoBehaviour
{
    public float angle = 0f;

    void Start()
    {
        angle = Random.Range(0f, 6.28f);
    }
}
