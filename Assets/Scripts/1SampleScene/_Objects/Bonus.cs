using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve scaleCurve;

    private Rigidbody2D rb => GetComponent<Rigidbody2D>();

    private float angle = 0;
    [SerializeField]
    private float speed = 25;
    private float scale = 0;

    void Start()
    {
        transform.position = new Vector3(0,0,0);
        transform.localScale = new Vector3(scale,scale,scale);
        
        angle = Random.Range(0f,Mathf.PI * 2);
        
        float posX = Mathf.Cos(angle);
        float posY = Mathf.Sin(angle);
        rb.AddForce(new Vector2(posX, posY) * speed);
    }
    void Update()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        float range = Mathf.Sqrt(x * x + y * y);
        if(range > 10f)
        {
            Destroy(gameObject);
        }
        scale = scaleCurve.Evaluate(range);
        transform.localScale = new Vector2(scale,scale);
    }
}
