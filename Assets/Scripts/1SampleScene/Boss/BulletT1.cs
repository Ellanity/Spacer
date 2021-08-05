using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletT1 : MonoBehaviour
{
    private GameObject Player => GameObject.FindGameObjectWithTag("Player");
    private float Speed = 50;
    void Start()
    {
        Vector3 PlayerPosition = Player.transform.position;
        Vector3 Direction = PlayerPosition - transform.position;
        GetComponent<Rigidbody2D>().AddForce(Direction * Speed);
    }

    void Update()
    {
        float posx = transform.position.x;
        float posy = transform.position.y;
        if(posx * posx + posy * posy >= 49)
            Destroy(gameObject);
    }
}
