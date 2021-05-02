using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shooting : MonoBehaviour
{
    [SerializeField]
    private GameObject Player => GameObject.FindGameObjectWithTag("Player");
    [SerializeField]
    private GameObject Prefab;
    private float TempTime;
    [SerializeField]
    private float MinDelay;
    [SerializeField]
    private float MaxDelay;
    private float Delay = 3;
    private float Speed = 100;

    public void EnemyShoot()
    {
        Delay = Random.Range(MinDelay, MaxDelay);
        TempTime = 0;
        GameObject newBullet = Instantiate(Prefab);
        newBullet.transform.position = transform.position;
        Vector3 PlayerPosition = Player.transform.position;
        Vector3 Direction = PlayerPosition - transform.position;
        newBullet.GetComponent<Rigidbody2D>().AddForce(Direction * Speed);
    }
}
