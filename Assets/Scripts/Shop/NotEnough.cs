using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotEnough : MonoBehaviour
{
    public float TempTime = 3f;
    // Update is called once per frame
    void Update()
    {
        TempTime += Time.deltaTime;
        float temp = (2f - TempTime) / 2f;
        GetComponent<Text>().color = new Color(1,0,0,temp);
        if(TempTime > 2f)
            this.enabled = false;
    }
}
