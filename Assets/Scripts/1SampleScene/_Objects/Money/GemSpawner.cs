using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    private Vector3 _target;
    private Stats _moneyStats;
    [SerializeField]
    private GameObject MoneyPrefab;
    [SerializeField]
    [Range(0,100)]
    private int _chanceToSpawnMoney = 100;

    [SerializeField]
    private int _minMoneyCount = 0;
    [SerializeField]
    private int _maxMoneyCount = 0;
    public void SpawnMoney()
    {   
        int Proc = Random.Range(0,99999999) % 100;
        if(Proc > _chanceToSpawnMoney)
            return;

        int CountMoney = Random.Range(_minMoneyCount, _maxMoneyCount);
        _target = GameObject.Find("Gems").transform.GetChild(0).gameObject.transform.position;
        _moneyStats = GameObject.Find("MoneyCounter").gameObject.GetComponent<Stats>();;
        for(int i = 0; i < CountMoney; i++)
        {
            GameObject newMoney = Instantiate(MoneyPrefab);
            newMoney.transform.position = transform.position + new Vector3(Random.Range(-0.2f,0.2f), Random.Range(-0.2f,0.2f), 0);
            GemsFlyToCollect newMFTC = newMoney.GetComponent<GemsFlyToCollect>();
            newMFTC._target = _target;
            newMFTC._spawnPoint = transform.position;
            newMFTC._moneyContainer = _moneyStats;
        }
    }
}
