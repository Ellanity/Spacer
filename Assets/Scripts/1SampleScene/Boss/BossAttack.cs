using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject LeftRay;
    [SerializeField]
    private GameObject RightRay;

    [SerializeField]
    private float AttackDelay;

    private float TempTime = 0f;
    void Update()
    {
        TempTime += Time.deltaTime;
        if(TempTime > AttackDelay)
        {
            TempTime = 0;
            Attack();
        }
    }
    void Attack()
    {
        AttackDelay = 10f;
        int TypeAttack = Random.Range(0,1);
        if(TypeAttack == 0)
        {
            RayAttack();
        }
        if(TypeAttack == 1)
        {
            ShootAttack();
        }
    }

    void RayAttack()
    {
        float EulerAngle = GlobalCache.Inst.PlayerAngle * Mathf.Rad2Deg;
        if(EulerAngle < 0)
            EulerAngle += 360;
        if(EulerAngle > 180)
        {
            LeftRay.transform.rotation = Quaternion.Euler(new Vector3(0,0,90));
            RightRay.transform.rotation = Quaternion.Euler(new Vector3(0,0,90));
            LeftRay.GetComponent<LaserRay>().DirectionZ = 1f;
            RightRay.GetComponent<LaserRay>().DirectionZ = -1f;
        }
        else
        {
            LeftRay.transform.rotation = Quaternion.Euler(new Vector3(0,0,-90));
            RightRay.transform.rotation = Quaternion.Euler(new Vector3(0,0,-90));
            LeftRay.GetComponent<LaserRay>().DirectionZ = -1f;
            RightRay.GetComponent<LaserRay>().DirectionZ = 1f;
        }
        LeftRay.GetComponent<LaserRay>().startAngle = LeftRay.transform.rotation.eulerAngles.z;
        RightRay.GetComponent<LaserRay>().startAngle = LeftRay.transform.rotation.eulerAngles.z;
        LeftRay.SetActive(true);
        RightRay.SetActive(true);
    }

    void ShootAttack()
    {

    }
}
