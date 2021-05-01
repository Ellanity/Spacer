using System.Collections;
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
    private float delay = 3f;

    public bool BossDefeated = false;
    public int flag = -1;

    void Update()
    {
        TempTime += Time.deltaTime;
        if((delay != 0f && delay < TempTime) || (delay == 0f && BossDefeated))
        {
            flag = Random.Range(0,100);
            //Debug.Log(flag);
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
        if(flag < 45)
        {
            delay = Random.Range(20f,50f);
            //delay = 10f;
            _MeteoriteText.SetActive(true);
            _MeteoriteGenerator.SetActive(true);
        }
        else if(flag < 80)
        {
            delay = Random.Range(20f,50f);
            //delay = 5f;
            _EnemyText.SetActive(true);
            _EnemyGenerator.SetActive(true);
        }
        else if(flag < 100)
        {
            delay = 0;
            BossDefeated = false;
            _BossText.SetActive(true);
            _BossGenerator.SetActive(true);
        }
        TempTime = 0;
        flag = -1;
    }

}
