using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject Prefab;
    public void SpawnBoss()
    {
        Instantiate(Prefab);
    }
}
