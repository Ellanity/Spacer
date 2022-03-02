using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRay : MonoBehaviour
{
    public float _temp;
    private void Update() {
        _temp -= Time.deltaTime;
        if(_temp < 0)
            gameObject.SetActive(false);
    }    
}
