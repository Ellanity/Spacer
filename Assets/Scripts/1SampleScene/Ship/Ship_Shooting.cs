using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Shooting : MonoBehaviour
{
    [SerializeField] private float _delay;
    private float _upgradeTime = GlobalCache.Inst.WeaponUpgradeCount * 0.025f;
    [SerializeField] private GameObject Bullet;
    private float _tempTime = 0;
    private Vector3 Offset = new Vector3 (0, 0, 90);
    void Update()
    {
        _tempTime += Time.deltaTime;
        //if(Input.GetAxis("Fire1") != 0)
        //    Shoot();
        Shoot();
    }
    [SerializeField] private List <string> _targetList;
    void Shoot()
    {

        int layerMask = 1 << 7;
        //layerMask = ~layerMask;
        
        Vector2 _direction = transform.position.normalized * -1;
        float _attackRange = Vector2.Distance(transform.position, Vector2.zero) / 4 * 3;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, _direction, _attackRange, layerMask);
        //Debug.DrawRay(transform.position, _direction * _attackRange, Color.yellow);

        if(!hit)
            return;

        string cur = hit.transform.gameObject.tag; 
        if(cur == "shield")
            return;
        for(int i = 0; i < _targetList.Count; i++)
        {
            //Debug.Log(cur + " " + _targetList[i]);
            if(_tempTime > _delay - _upgradeTime && _targetList[i] == cur)
            {
                FindObjectOfType<AudioManager>().Play("PlayerShoot");
                _tempTime = 0;
                GameObject NewBullet = Instantiate(Bullet);
                NewBullet.transform.position = transform.position;
                float angle = GetComponent<Ship_Movement>().Angle * Mathf.Rad2Deg; 
                NewBullet.transform.rotation = Quaternion.Euler(Offset + new Vector3(0, 0, angle));
            }
        }
    }
}
