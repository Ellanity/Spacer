﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    [SerializeField]
    private GameObject _MeteoriteGenerator;
    [SerializeField]
    private GameObject _EnemyGenerator;
    [SerializeField]
    private GameObject _BossGenerator;

    [SerializeField]
    private GameObject _MeteoriteText;
    [SerializeField]
    private GameObject _EnemyText;
    [SerializeField]
    private GameObject _BossText;

    private float TempTime = 0;
    private float GlobalTime => GetComponent<GlobalTime>().time;
    private float delay = 3f;

    private int flag = -1;

    private float BossTimeTrigger = 50f;

    void Update()
    {
        TempTime += Time.deltaTime;
        if((delay != 0f && delay < TempTime) || (delay == 0f && GlobalCache.Inst.BossDefeated))
        {
            int maxValue = 100;
            if(GlobalTime < BossTimeTrigger)
                maxValue = 84;
            flag = Random.Range(0, maxValue);
            Debug.Log(flag);
            StartEvent(flag);
        }
        if(TempTime >= 3f && flag != -1)
        {
            _MeteoriteText.SetActive(false);
            _EnemyText.SetActive(false);
            _BossText.SetActive(false);
        }
    }

    void StartEvent(int flag)
    {
        _BossGenerator.SetActive(false);
        _EnemyGenerator.SetActive(false);
        _MeteoriteGenerator.SetActive(false);
        if(flag < 50)
        {
            delay = Random.Range(20f,50f);
            _MeteoriteText.SetActive(true);
            _MeteoriteGenerator.SetActive(true);
        }
        else if(flag < 85)
        {
            delay = Random.Range(20f,50f);
            _EnemyText.SetActive(true);
            _EnemyGenerator.SetActive(true);
        }
        else if(flag < 100)
        {
            delay = 0;
            GlobalCache.Inst.BossDefeated = false;
            _BossText.SetActive(true);
            _BossGenerator.GetComponent<BossGenerator>().SpawnBoss();
        }
        TempTime = 0;
        flag = -1;
    }

}
