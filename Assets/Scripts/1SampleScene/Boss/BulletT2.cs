using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletT2 : MonoBehaviour
{
    [SerializeField]
    private float speed = 50f;
    private Rigidbody2D rb => GetComponent<Rigidbody2D>();
    private float TempTime = 0f;

    void Update()
    {
        TempTime += Time.deltaTime;
        if(TempTime > 2f && TempTime < 10f)
        {    
            TempTime = 11f;
            float posX = -transform.position.x;
            float posY = -transform.position.y;
            rb.AddForce(new Vector2(posX, posY) * speed);
        }
        float PosX = transform.position.x;
        float PosY = transform.position.y;
        if(Mathf.Abs(PosX) < 0.2 && Mathf.Abs(PosY) < 0.2)
            Destroy(gameObject);
    }
}
