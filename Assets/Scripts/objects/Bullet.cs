using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float radius;
    public float angle;
    public float speed = 5f;

    public AnimationCurve Scale;


    void Start()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        radius = Mathf.Sqrt(x * x + y * y);
        if (Mathf.Asin(y / radius) > 0)
            angle = Mathf.Acos(x / radius);
        else
            angle = -Mathf.Acos(x / radius);
       
    }

    // Update is called once per frame
    void Update()
    {
        radius = radius - speed * Time.deltaTime;
        float posX = Mathf.Cos(angle) * radius;
        float posY = Mathf.Sin(angle) * radius;
        transform.position = new Vector2(posX, posY);
        if (radius < 0.01f)
        {
            Destroy(gameObject);
        }
        float scale = Scale.Evaluate(radius); ;
        if (scale < 0.00001f)
            Destroy(gameObject);
        transform.localScale = new Vector3(scale, scale, scale);

    }
}
