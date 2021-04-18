using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Shooting : MonoBehaviour
{
    private float TempTime = 0;
    [SerializeField]
    private float Delay;
    [SerializeField]
    private GameObject Bullet;
    private Vector3 Offset = new Vector3 (0, 0, 90);

    void Update()
    {
        TempTime += Time.deltaTime;
        if(Input.GetAxis("Fire1") != 0)
            Shoot();
    }

    void Shoot()
    {
        if(TempTime > Delay)
        {
            TempTime = 0;
            GameObject NewBullet = Instantiate(Bullet);
            NewBullet.transform.position = transform.position;
            float Angle = GetComponent<Ship_Movement>().Angle;
            NewBullet.transform.rotation = Quaternion.Euler(Offset + new Vector3(0, 0, Angle * Mathf.Rad2Deg));
        }
    }
}
