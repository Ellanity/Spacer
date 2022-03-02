using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject Prefab;
    [SerializeField] Transform _parent;
    public void SpawnBoss()
    {
        GameObject _new = Instantiate(Prefab);
        _new.transform.parent = _parent;
    }
}
