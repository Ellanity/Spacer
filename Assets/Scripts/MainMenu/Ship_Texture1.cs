using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ship_Texture1 : MonoBehaviour
{
    //[SerializeField]
    //private List<Color> Materials;
    //private Image _main => GetComponent<Image>();
    private Renderer _main => GetComponent<Renderer>();
    private bool _flag = true;

    void Start()
    {
        //Debug.Log(Materials[GlobalCache.Inst.ShipTexture]);
        //_main.color = Materials[GlobalCache.Inst.ShipTexture];
        
    }
    void FixedUpdate()
    {
        if(_flag)
        {
            _main.material = GlobalCache.Inst.ShipMaterials[GlobalCache.Inst.ShipTexture];
            _flag = false;
            return;
        }
    }
}
