using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Trigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "bullet" && !transform.GetChild(0).gameObject.activeInHierarchy)
        {
            GetComponent<MoneySpawner>().SpawnMoney();
            FindObjectOfType<AudioManager>().Play("LittleBoom");
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
