using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 200f;
    private Rigidbody2D rb => GetComponent<Rigidbody2D>();
    [SerializeField]
    private AnimationCurve Scale;
    void Start()
    {
        float posX = -transform.position.x;
        float posY = -transform.position.y;
        rb.AddForce(new Vector2(posX, posY) * speed);
    }
    void Update()
    {
        float PosX = transform.position.x;
        float PosY = transform.position.y;
        if(Mathf.Abs(PosX) < 0.2 && Mathf.Abs(PosY) < 0.2)
            Destroy(gameObject);
        float TempScale = Scale.Evaluate(PosX * PosX + PosY * PosY);
        transform.localScale = new Vector3(TempScale, TempScale, 1);
    }
}
