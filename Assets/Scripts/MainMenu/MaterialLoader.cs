using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialLoader : MonoBehaviour
{
    [SerializeField]
    private List <Material> _shipMaterials;
    void Start()
    {
        if(!GlobalCache.Inst.IsLoadedMaterials)
        {
            //Debug.Log(_shipMaterials);
            for(int i = 0; i < _shipMaterials.Count; i++)
            {
                GlobalCache.Inst.ShipMaterials.Add(_shipMaterials[i]);
            }
            GlobalCache.Inst.IsLoadedMaterials = true;
        }
    }
}
