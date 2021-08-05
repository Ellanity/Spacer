using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{

    [SerializeField]
    private float AttackDelay;

    private float TempTime = 0f;

    private int PrevTypeAttack = 0;
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
        //AttackDelay = 5f;
        int TypeAttack = Random.Range(0,3);
        //int TypeAttack = 0;
        if(TypeAttack == 0 && PrevTypeAttack != 0)
        {
            AttackDelay = 5f;
            PrevTypeAttack = 0;
            RayAttack();
        }
        else if(TypeAttack == 1 && PrevTypeAttack != 1)
        {
            AttackDelay = 1f;
            PrevTypeAttack = 1;
            ShootAttack();
        }
        else if(TypeAttack == 2 && PrevTypeAttack != 2)
        {
            AttackDelay = 2f;
            PrevTypeAttack = 2;
            BehindBlades();
        }
        else
        {
            AttackDelay = -1f;
        }
    }

    [SerializeField]
    private GameObject LeftRay;
    [SerializeField]
    private GameObject RightRay;
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

    private int ShootCount = 0;
    void ShootAttack()
    {   
        ShootCount = 0;
        Shoot();
    }
    [SerializeField]
    private GameObject BulletType1;
    void Shoot()
    {
        if(ShootCount >= 3)
            return;
        ShootCount++;
        GameObject newBullet = Instantiate(BulletType1);
        newBullet.SetActive(true);
        Invoke("Shoot",0.3f);
    }
    private List <GameObject> AllRedPoints = new List<GameObject>();
    [SerializeField]
    private GameObject BulletType2;
    void BehindBlades()
    {
        float SpawnRadius = 5.2f;
        float SpawnRange = 0.2f;
        float EulerAngle = GlobalCache.Inst.PlayerAngle;
        
        //Debug.Log(EulerAngle);
        for(int i = -3; i <= 3; i++)
        {
            float TempAngle = EulerAngle - SpawnRange * i;
            //Debug.Log(TempAngle);
            Vector3 Position = new Vector3(Mathf.Cos(TempAngle) * SpawnRadius, Mathf.Sin(TempAngle) * SpawnRadius, 1f);
            GameObject NewRedPoint = Instantiate(BulletType2);
            NewRedPoint.SetActive(true);
            NewRedPoint.transform.position = Position;
            AllRedPoints.Add(NewRedPoint);
        }
    }
}
