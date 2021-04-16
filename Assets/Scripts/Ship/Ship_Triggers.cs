using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ship_Triggers : MonoBehaviour
{
    [SerializeField]
    private float HealthPoints = 3;
    private GameObject Shield => transform.GetChild(2).gameObject; 
    [SerializeField]
    private Text LivesCounter;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "bonus_hp")
        {
            AddHP();
            Destroy(other.gameObject);
        }
        if (other.tag == "bonus_shield")
        {
            Invulnerability();
            Destroy(other.gameObject);
        }
        if ((other.tag == "meteorite" || other.tag == "enemy") && (!Shield.activeSelf))
        {
            RemoveHP();
            Invulnerability();
            Destroy(other.gameObject);
        }
    } 

    void AddHP()
    {
        //if(HealthPoints < 3)
        HealthPoints++;
        LivesCounter.text = "x " + HealthPoints.ToString();
    }
    void RemoveHP()
    {
        if(HealthPoints > 0)
        {
            HealthPoints--;
            LivesCounter.text = "x " + HealthPoints.ToString();
        }
        else
            SceneManager.LoadScene(1);
    }
    void Invulnerability()
    {
        Shield.GetComponent<Shield>().TempTime = 0;
        Shield.SetActive(true);
    }
}
