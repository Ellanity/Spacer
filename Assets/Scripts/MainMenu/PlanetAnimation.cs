using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetAnimation : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed = 1;
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, _rotationSpeed)/10);
    }
}
