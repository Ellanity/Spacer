using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [HideInInspector] public float TempTime;
    private float baseTime = 3f;
    private float _shieldUpgrade = GlobalCache.Inst.ShieldUpgradeCount * 0.2f;
    private void Start() 
    {
        if(transform.parent.tag != "Player")    
            _shieldUpgrade = 0;
    }
    private void Update()
    {
        TempTime += Time.deltaTime;
        if(TempTime > baseTime)
            SetInactive();
    }
    private void SetInactive()
    {
        gameObject.SetActive(false);
    }
}
