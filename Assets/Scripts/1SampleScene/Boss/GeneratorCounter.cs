using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorCounter : MonoBehaviour
{
    public int counter = 4;
    [SerializeField]
    private GameObject BossShield => transform.parent.GetChild(0).gameObject;
    private float TempTime = 0f;
    private bool flag = false;
    public void MinusCounter()
    {
        counter--;
        if(counter == 0)
        {
            BossShield.SetActive(false);
            TempTime = 0f;
            flag = true;
        }
    }
    private void ActivateShield()
    {
        BossShield.SetActive(true);
        counter = 4;
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(true);
        transform.GetChild(2).gameObject.SetActive(true);
        transform.GetChild(3).gameObject.SetActive(true);
    }
    void Update()
    {
        TempTime += Time.deltaTime;
        if(TempTime >= 3f && flag == true)
        {
            flag = false;
            ActivateShield();
        }
    }
}
