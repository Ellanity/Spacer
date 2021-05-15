using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorCounter : MonoBehaviour
{
    public int counter = 4;
    [SerializeField]
    private GameObject BossShield => transform.parent.GetChild(0).gameObject;
    public void MinusCounter()
    {
        counter--;
        if(counter == 0)
        {
            BossShield.SetActive(false);
        }
    }
}
