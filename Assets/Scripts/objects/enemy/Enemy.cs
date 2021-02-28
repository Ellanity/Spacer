using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float time;
    public AnimationCurve Speed;
    public AnimationCurve Scale;
    public AnimationCurve koef;
    public float radius = 0f;
    private float posX;
    private float posY;
    public float speed = 0.2f;
    private float rotation;
    public float angle;

    private void Start()
    {
        this.transform.localScale = new Vector3(0, 0, 0);
        time = GameObject.Find("Generator").GetComponent<Generator>().time;

        angle = this.GetComponent<Enemy_Angle>().angle;
    }
    void Update()
    {
        radius = (float)(radius + speed * Time.deltaTime * koef.Evaluate(radius));
        posX = Mathf.Cos(angle) * radius;
        posY = Mathf.Sin(angle) * radius;
        transform.rotation = quaternion.RotateZ(angle);
        transform.Rotate(0, 0, 90);
        transform.position = new Vector2(posX, posY);
        if (radius > 8f)
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
