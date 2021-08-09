using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ship_Movement : MonoBehaviour
{
    //[SerializeField]
    //private AnimationCurve RadiusScale;
    [SerializeField]
    private float Radius = 4f;
    [SerializeField]    
    private float AngularSpeed = 20f;
    /*[SerializeField]
    private float RadiusSpeed = 2f;
    [SerializeField]
    private float MaxRadius = 5f;
    [SerializeField]
    private float MinRadius = 3f;*/
    [HideInInspector]
    public float Angle;
    private Vector3 Offset = new Vector3 (0, 0, 90);
    private bool _pressedLeft = false;
    private bool _pressedRight = false;
    
    void Start()
    {
        Angle = -90 * Mathf.Deg2Rad;
    }

    public void DownLeft()
    {
        _pressedLeft = true;
        //Debug.Log("Left button is pressed");
    }
    public void DownRight()
    {
        _pressedRight = true;
        //Debug.Log("Right button is pressed");
    }
    public void UpLeft()
    {
        _pressedLeft = false;
    }
    public void UpRight()
    {
        _pressedRight = false;
    }
    void Update()
    {
        float XPosition = Mathf.Cos(Angle) * Radius;
        float YPosition = Mathf.Sin(Angle) * Radius;
        transform.position = new Vector2(XPosition, YPosition);
        transform.rotation = Quaternion.Euler(Offset + new Vector3(0, 0, Angle * Mathf.Rad2Deg));
        
        //Angle += Input.GetAxis("Horizontal") * AngularSpeed * Time.deltaTime;
        //Radius = Mathf.Min(MaxRadius, Mathf.Max(MinRadius, Radius - Input.GetAxis("Vertical") * RadiusSpeed * Time.deltaTime));
        if(_pressedLeft)
            Angle -= AngularSpeed * Time.deltaTime;
        if(_pressedRight)
            Angle += AngularSpeed * Time.deltaTime;
        //float Scale = RadiusScale.Evaluate(Radius);
        //transform.localScale = new Vector3(Scale, Scale, Scale);
        
        if (Mathf.Abs(Angle) >= Mathf.PI * 2)
            Angle = Mathf.Abs(Angle) - Mathf.PI * 2;
        GlobalCache.Inst.PlayerAngle = Angle;
    }
    
    /*
                            ROLF
    void FixedUpdate()
    {

        float XPosition = Mathf.Cos(Angle) * Radius;
        float YPosition = Mathf.Sin(Angle) * Radius;
        transform.position = new Vector2(XPosition, YPosition);
        transform.rotation = Quaternion.Euler(Offset + new Vector3(0, 0, Angle * Mathf.Rad2Deg));
        
        Angle += Input.GetAxis("Horizontal") * AngularSpeed;
        Radius = Mathf.Min(MaxRadius, Mathf.Max(MinRadius, Radius - Input.GetAxis("Vertical") * RadiusSpeed));

        float Scale = RadiusScale.Evaluate(Radius);
        transform.localScale = new Vector3(Scale, Scale, Scale);
        
        if (Angle >= Mathf.PI * 2)
            Angle -= Mathf.PI * 2;
    }
    */
}
