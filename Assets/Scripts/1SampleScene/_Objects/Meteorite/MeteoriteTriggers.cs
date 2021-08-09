    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteTriggers : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "bullet")
        {
            GetComponent<MoneySpawner>().SpawnMoney();
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
