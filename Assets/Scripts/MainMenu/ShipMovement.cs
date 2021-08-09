using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve _yAnimation;
    private float _expiredTime;
    private float _duration = 3;
    private Vector3 _startPosition;
    void Start()
    {
        _startPosition = transform.position;
    }
    void Update()
    {
        _expiredTime += Time.deltaTime;
        if(_expiredTime > _duration)
            _expiredTime = 0;
        float progress = _expiredTime / _duration;
        transform.position = _startPosition + new Vector3(0, _yAnimation.Evaluate(progress), 0);
        //  Debug.Log(progress);
    }
}
