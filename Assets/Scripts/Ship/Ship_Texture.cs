using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Texture : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> Textures;
    private SpriteRenderer Main => GetComponent<SpriteRenderer>();


    void Start()
    {
        Main.sprite = Textures[GlobalCache.Inst.ShipTexture];
    }
}
