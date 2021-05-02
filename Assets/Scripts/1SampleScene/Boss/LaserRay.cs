using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRay : MonoBehaviour
{
    public float startAngle;
    public float DirectionZ = 1f;
    void FixedUpdate()
    {
        transform.Rotate(0,0,DirectionZ);
        float curAngle = transform.rotation.eulerAngles.z;
        //Debug.Log(startAngle.ToString() + "\n" + curAngle.ToString());
        if(startAngle == 270 && 92 >= curAngle && curAngle >= 88)
            gameObject.SetActive(false);
        if(startAngle == 90 && 268 <= curAngle && curAngle <= 272)
            gameObject.SetActive(false);    
    }
}
