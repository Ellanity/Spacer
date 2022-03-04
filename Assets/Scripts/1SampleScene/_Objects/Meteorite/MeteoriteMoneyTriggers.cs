using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteMoneyTriggers : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "bullet")
        {
            GetComponent<MoneySpawner>().SpawnMoney();
            FindObjectOfType<AudioManager>().Play("LittleBoom");
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
