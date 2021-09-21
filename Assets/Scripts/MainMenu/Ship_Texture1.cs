using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ship_Texture1 : MonoBehaviour
{
    [SerializeField]
    private List<Color> Materials;
    private Image _main => GetComponent<Image>();


    void Start()
    {
        //Debug.Log(Materials[GlobalCache.Inst.ShipTexture]);
        _main.color = Materials[GlobalCache.Inst.ShipTexture];
    }
}
