using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.VFX;

public class Generator : MonoBehaviour
{
    public List<Met> meteoritePrefab;
    private List<Met> meteoriteList;

    public Star starPrefab;
    private List<Star> starList;

    public List<Bonus> bonusPrefabs;

    public Enemy enemyPrefab;

    public AnimationCurve Delay_met;
    public AnimationCurve Delay_enemy;

    public float time = 0f;

    private float time1 = 0f;
    private float time2 = 0f;
    private float time3 = 0f;
    private float time4 = 0f;
    private float time5 = 0f;

    public float delay_star = 0.05f;
    public float delay_met = 0f;
    public float delay_bonus = 1f;
    public float delay_enemy = 1f;

    private float countSave = 0;
    private float koef = 0;
    public float angle = 0f;

    private void Start()
    {

    }

    void Update()
    {
        //spawnMeteorite();
        spawnStar();
        spawnBonus();
        spawnEnemy();
        fixedAngle();


        time += Time.deltaTime;
        time1 += Time.deltaTime;
        time2 += Time.deltaTime;
        time3 += Time.deltaTime;
        time4 += Time.deltaTime;
        time5 += Time.deltaTime;
    }

    void spawnStar()
    { 
        if (time1 > delay_star)
        {
            time1 = 0;
            Star newStar = Instantiate(starPrefab);
            newStar.transform.position = new Vector3(Random.Range(-4f,4f), Random.Range(-4f, 4f), 0);
        }
    }
   
    void spawnMeteorite()
    {
        delay_met = Delay_met.Evaluate(time);
        if (time2 > delay_met)
        {
            time2 = 0;
            Met newMeteorite = Instantiate(meteoritePrefab[Random.Range(0,meteoritePrefab.Count)]);
            newMeteorite.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
            newMeteorite.transform.position = new Vector3(0, 0, 0);
            newMeteorite.transform.localScale = new Vector3(0, 0, 0);
        }
    }

    void spawnBonus()
    {
        if(time3 > delay_bonus)
        {
            time3 = 0;
            delay_bonus = Random.Range(3, 10);
            Bonus newBonus = Instantiate(bonusPrefabs[Random.Range(0, bonusPrefabs.Count)]);
            newBonus.transform.position = new Vector3(0, 0, 0);
            newBonus.transform.localScale = new Vector3(0, 0, 0);
        }
    }

    void fixedAngle()
    {
        //while (true)
        if (time4 < 0.3f)
            return;
        time4 = 0f;
        countSave++;
        float rand = 0;
        if (countSave > 3)
        {
            countSave = 0;
            rand = Random.Range(0f, 100f);
            if (rand > 50)
                koef = 1 - koef;
        }
        if (koef == 0)
            angle += Random.Range(0f, 0.4f);
        else
            angle -= Random.Range(0f, 0.4f);

        if (angle < 0)
            angle = 6.28f + angle;
        else if (angle > 6.28f)
            angle = 0 + (angle - 6.28f);

    }
    
    void spawnEnemy()
    {
        float delay_enemy = Delay_enemy.Evaluate(time);
        if(time5 > delay_enemy)
        {
            time5 = 0;
            Enemy newEnemy = Instantiate(enemyPrefab);
            enemyPrefab.transform.position = new Vector3(0, 0, 0);
            enemyPrefab.transform.localScale = new Vector3(0, 0, 0);
        }
    }
}
