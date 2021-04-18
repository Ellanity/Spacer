using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Movement : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve RadiusScale;
    private float Radius = 2f;
    [SerializeField]    
    private float AngularSpeed = 2f;
    [SerializeField]
    private float RadiusSpeed = 2f;
    [SerializeField]
    private float MaxRadius =5f;
    [SerializeField]
    private float MinRadius = 3f;
    [HideInInspector]
    public float Angle = 0f;
    private Vector3 Offset = new Vector3 (0, 0, 90);
    
    void Update()
    {
        float XPosition = Mathf.Cos(Angle) * Radius;
        float YPosition = Mathf.Sin(Angle) * Radius;
        transform.position = new Vector2(XPosition, YPosition);
        transform.rotation = Quaternion.Euler(Offset + new Vector3(0, 0, Angle * Mathf.Rad2Deg));
        
        Angle += Input.GetAxis("Horizontal") * AngularSpeed * Time.deltaTime;
        Radius = Mathf.Min(MaxRadius, Mathf.Max(MinRadius, Radius - Input.GetAxis("Vertical") * RadiusSpeed * Time.deltaTime));

        float Scale = RadiusScale.Evaluate(Radius);
        transform.localScale = new Vector3(Scale, Scale, Scale);
        
        if (Angle >= Mathf.PI * 2)
            Angle -= Mathf.PI * 2;
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
