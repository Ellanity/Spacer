using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    private float time;
    public AnimationCurve Scale;
    public AnimationCurve Speed;
    public float radius;
    private float posX;
    private float posY;
    private float angle;
    public float speed = 20f;
    private float rotation;

    //public time = 

    private void Start()
    {
        time = GameObject.Find("Generator").GetComponent<Generator>().time;
        //rotation = Random.Range(-0.1f, 0.1f);
        float x = transform.position.x;
        float y = transform.position.y;
        radius = Mathf.Sqrt(x * x + y * y);
        if(Mathf.Asin(y / radius) > 0)
            angle = Mathf.Acos(x / radius);
        else
            angle = -Mathf.Acos(x / radius);
    }
    void Update()
    {
        radius = radius + speed * Time.deltaTime;
        posX = Mathf.Cos(angle) * radius;
        posY = Mathf.Sin(angle) * radius;
        transform.position = new Vector2(posX, posY);
        if (radius > 8f)
        {
            Destroy(gameObject);
        }
        speed = Speed.Evaluate(time);
        float scale = Scale.Evaluate(radius); ;
        transform.localScale = new Vector3(scale, scale, scale);
        //transform.Rotate(0, 0, rotation);
    }
}
