using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Trigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "bullet" && !transform.GetChild(0).gameObject.activeInHierarchy)
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
