using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemsFlyToCollect : MonoBehaviour
{
    [HideInInspector]
    public Vector3 _target;
    [HideInInspector]
    public Vector3 _spawnPoint;
    [HideInInspector]
    public Stats _moneyContainer;
    [SerializeField]
    private float _speed = 1;
    [SerializeField]
    private float _delay = 0.2f;
    private float TempTime;
    void Start()
    {
        //Debug.Log(transform.position);
        //Debug.Log(_target);
    }

    void Update()
    {
        float speed = _speed / Mathf.Max(2 - TempTime, 1);
        if(TempTime < _delay)
        {
            TempTime += Time.deltaTime;
            transform.position += (transform.position - _spawnPoint) * speed * Time.deltaTime;
        }
        else
        {
            transform.position += (_target - transform.position) * speed * Time.deltaTime;
        }
        if(transform.position.x + 0.2 >= _target.x && transform.position.y + 0.2 >= _target.y)
        {
            _moneyContainer.AddGem(1);
            Destroy(gameObject);
        }
    }
}
