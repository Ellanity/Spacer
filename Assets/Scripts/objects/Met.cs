using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Met : MonoBehaviour
{
    public float time;
    public AnimationCurve Speed;
    public AnimationCurve Scale;
    public AnimationCurve koef;
    public float radius = 0f;
    private float posX;
    private float posY;
    private float angle = 0f;
    public float speed = 0.2f;
    private float rotation;
    private float saveAngle;
    //public time = 

    private void Start()
    {
        saveAngle = GameObject.Find("Generator").GetComponent<Generator>().angle;
        time = GameObject.Find("Generator").GetComponent<Generator>().time;
        
        fixeAngle();

        rotation = Random.Range(-0.1f, 0.1f);
    }

    void fixeAngle()
    { 
        float maxAngle = saveAngle + 1.4f;

        if (maxAngle > 6.28f)
            angle = Random.Range(maxAngle - 6.28f, saveAngle);

        else
        {
            if (Random.Range(0f, 6.28f) <= saveAngle)
                angle = Random.Range(0f, saveAngle);
            else
                angle = Random.Range(maxAngle, 6.28f);
        }

    }
    void Update()
    {
        radius = (float)(radius + speed * Time.deltaTime * koef.Evaluate(radius));
        posX = Mathf.Cos(angle) * radius;
        posY = Mathf.Sin(angle) * radius;
        transform.position = new Vector2(posX, posY);
        if(radius > 8f)
        {
            Destroy(gameObject);
        }
        speed = Speed.Evaluate(time);
        float scale = Scale.Evaluate(radius); ;
        transform.localScale = new Vector3(scale, scale, 0);
        transform.Rotate(0, 0, rotation);
        if (Time.timeScale == 0)
            transform.Rotate(0, 0, -rotation);
    }
}
