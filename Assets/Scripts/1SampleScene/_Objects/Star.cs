using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public AnimationCurve scale;
    private float radius = 0;
    private float angle = 0;    
    private float speed = 15f;
    void Start()
    {
        transform.position = new Vector3(Random.Range(-4f,4f), Random.Range(-4f, 4f), 0);
        float x = transform.position.x;
        float y = transform.position.y;
        radius = Mathf.Sqrt(x * x + y * y);
        if(Mathf.Asin(y / radius) > 0)
            angle = Mathf.Acos(x / radius);
        else
            angle = -Mathf.Acos(x / radius);
    }

    // Update is called once per frame
    void Update()
    {
        radius = radius + speed * Time.deltaTime;
        float posX = Mathf.Cos(angle) * radius;
        float posY = Mathf.Sin(angle) * radius;
        transform.position = new Vector2(posX, posY);
        if (radius > 10f)
        {
            Destroy(gameObject);
        }
        float TempScale = scale.Evaluate(radius);
        transform.localScale = new Vector3(TempScale, TempScale, TempScale);
    }
}
