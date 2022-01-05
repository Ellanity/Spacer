using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotEnough : MonoBehaviour
{
    public float TempTime = 3f;
    [SerializeField] private Color _color;
    void Update()
    {
        TempTime += Time.deltaTime;
        float temp = TempTime / 2f;
        GetComponent<Text>().color = _color - new Color(0,0,0,temp);
        if(TempTime > 2f)
            this.enabled = false;
    }
    public void SetTrue()
    {
        GetComponent<NotEnough>().TempTime = 0f;
        GetComponent<Text>().color = _color;
    }
}
