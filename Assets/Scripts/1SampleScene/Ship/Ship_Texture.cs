using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Texture : MonoBehaviour
{
    [SerializeField]
    private List<Color> Materials;
    private Material _main => GetComponent<Renderer>().material;


    void Start()
    {
        _main.color = Materials[GlobalCache.Inst.ShipTexture];
    }
}
