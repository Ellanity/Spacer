using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.Mathematics;
using UnityEngine;

public class Ship_movement : MonoBehaviour
{
    public Transform centre;
    public Transform target;
    public float radius = 2f;
    public float angularSpeed = 2f;
    private float posX;
    private float posY;
    public  float angle = 0f;

    private void Start()
    {
        
    }
    void Update()
    {

        posX = centre.position.x + Mathf.Cos(angle) * radius;
        posY = centre.position.y + Mathf.Sin(angle) * radius;
        transform.position = new Vector2(posX, posY);
        transform.rotation = quaternion.RotateZ(angle);
        transform.Rotate(0, 0, 90);
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            angle = angle + Time.deltaTime * angularSpeed;
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            angle = angle - Time.deltaTime * angularSpeed;
        }

        if (angle >= 360f)
        {
            angle = 0f;
        }
    }

}
