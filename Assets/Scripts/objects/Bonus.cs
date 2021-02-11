using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    private float time;
    public AnimationCurve Scale;
    public AnimationCurve koef;
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
        angle = Random.Range(0f, 360f);
        rotation = Random.Range(-0.1f, 0.1f);
    }
    void Update()
    {
        radius = radius + speed * Time.deltaTime * koef.Evaluate(radius);
        posX = Mathf.Cos(angle) * radius;
        posY = Mathf.Sin(angle) * radius;
        transform.position = new Vector2(posX, posY);
        if (radius > 8f)
        {
            Destroy(gameObject);
        }
        float scale = Scale.Evaluate(radius); ;
        transform.localScale = new Vector3(scale, scale, scale);
        //transform.Rotate(0, 0, rotation);
    }
}
