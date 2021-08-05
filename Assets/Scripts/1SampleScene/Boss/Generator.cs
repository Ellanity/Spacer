using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    private GeneratorCounter _GM => transform.parent.gameObject.GetComponent<GeneratorCounter>();
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "bullet")
        {
            _GM.MinusCounter(); 
            Destroy(other.gameObject); 
            gameObject.SetActive(false);
        }
    }
}
