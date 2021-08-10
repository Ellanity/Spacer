using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve ScaleCurve;

    private Rigidbody2D rb => GetComponent<Rigidbody2D>();

    private float Angle = 0;
    [SerializeField]
    private float Speed = 80;
    private float Scale = 0;

    private bool flag = false;
    private float TempTime = 0;
    private float StopRange;
    [SerializeField]
    private float _maxStopRange;
    [SerializeField]
    private float _minStopRange;
    private float StopTime;

    private Vector3 Offset = new Vector3 (0, 0, 90);

    void Start()
    {
        StopRange = Random.Range(_minStopRange,_maxStopRange);
        StopTime = Random.Range(1f,3f);

        transform.position = new Vector3(0,0,0);
        transform.localScale = new Vector3(Scale,Scale,Scale);
        
        Angle = Random.Range(0f,Mathf.PI * 2);
        
        float posX = Mathf.Cos(Angle);
        float posY = Mathf.Sin(Angle);
        rb.AddForce(new Vector2(posX, posY) * Speed);
        transform.rotation = Quaternion.Euler(Offset + new Vector3(0, 0, Angle * Mathf.Rad2Deg));
    }
    void Update()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        float radius = Mathf.Sqrt(x * x + y * y);
        if(radius > 10f)
        {
            Destroy(gameObject);
        }
        Scale = ScaleCurve.Evaluate(radius);
        transform.localScale = new Vector2(Scale,Scale);


        if(radius > 2.5f)
            rb.AddForce(new Vector2(x, y));


        if(radius > StopRange && !flag)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            rb.velocity = Vector3.zero;
            TempTime += Time.deltaTime;
            if(TempTime > StopTime)
            {
                GetComponent<Enemy_Shooting>().EnemyShoot();
                GetComponent<Enemy_Shooting>().enabled = false;
                float posX = Mathf.Cos(Angle);
                float posY = Mathf.Sin(Angle);
                rb.AddForce(new Vector2(posX, posY) * Speed);
                flag = true;
            }
        }
    }
}
