using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Triggers : MonoBehaviour
{
    public stats stats;

    public float flag = 0;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "bonus_hp" && stats.countLives < 3)
        {
            flag = 2;
            Destroy(other.gameObject);
        }
        if (other.tag == "bonus_shield")
        {
            flag = 3;
            Destroy(other.gameObject);
        }
        if (other.tag == "meteorite")
            flag = 1;
        
        if (other.tag == "enemy")
            flag = 1;
    }
}
