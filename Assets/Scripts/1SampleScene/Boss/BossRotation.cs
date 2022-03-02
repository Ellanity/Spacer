using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRotation : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    private float _timeDirection = 0;
    private float _timeSpeed = 0;
    private float _direction = 1;
    [SerializeField] private float minSpeed,maxSpeed;
    float _timeWhenChange;
    void Start() 
    {
        float maxValue = 25f;
        float minValue = 10f;
        _timeWhenChange = Random.Range(minValue,maxValue);
        _rotationSpeed = Random.Range(minSpeed,maxSpeed);
        _direction = Random.Range(0f,100f) > 50 ? 1 : -1;
    }
    void Update()
    {
        _timeDirection += Time.deltaTime;
        _timeSpeed += Time.deltaTime;
        if(_timeDirection > _timeWhenChange)
        {
            _direction *= -1;
            _timeDirection = 0;
        }
        if(_timeSpeed > _timeWhenChange / 2)
        {
            _rotationSpeed = Random.Range(minSpeed, maxSpeed);
            _timeSpeed = 0;
        }
        transform.Rotate(0, 0, _rotationSpeed * Time.deltaTime * _direction, Space.Self);
    }
}
