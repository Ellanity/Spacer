using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stats : MonoBehaviour
{
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject ship;
    public GameObject shield;

    private Transform shipPOS;
    private Ship_Triggers hero;

    public float countLives = 3;
    private float time = 0;
    private float flick = 0;
    private float trigg = 0;
    private float flag;
    void Start()
    {
        shipPOS = ship.GetComponent<Transform>();
        hero = ship.GetComponent<Ship_Triggers>();
    }

    void Update()
    {
        time += Time.deltaTime;
        flick += Time.deltaTime;
        flag = hero.flag;
        
        if (flag == 3)
            shieldActivation();
        else if (time >= 3)
            shield.SetActive(false);
        
        if (trigg == 1)
            flicker();
        
        if (flag == 2)
            heartAdd(countLives);

        if (flag == 1 && time >= 3f)            
            heartDestroy(countLives);

        hero.flag = 0;
        
    }

    void shieldActivation()
    {
        shield.SetActive(true);
        time = 0;
    }

    void heartAdd(float countLivesb)
    {
        if (countLives == 2)
            heart1.SetActive(true);

        if (countLives == 1)
            heart2.SetActive(true);

        if (countLives == 0)
            heart3.SetActive(true);

        countLives++;
    }
   
    void heartDestroy(float countLivesb)
    {
        time = 0;
        trigg = 1;
        
        if (countLivesb == 3)
            heart1.SetActive(false);

        if (countLivesb == 2)
            heart2.SetActive(false);

        if (countLivesb == 1)
            heart3.SetActive(false);


        if (countLivesb == 0)
            SceneManager.LoadScene(1);

        countLives--;
    }

    void flicker()
    {
        if (time >= 3f)
        {
            trigg = 0;
            shipPOS.localScale = new Vector3(1, 1, 1);
            return;
        }
        if(flick >= 0.1)
        {
            Vector3 cur = shipPOS.localScale;
            shipPOS.localScale = new Vector3(1 - cur.x, 1 - cur.y, 1 - cur.z);
            flick = 0;
        }
    }
}
