using CI.QuickSave;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GlobalCache//: MonoBehaviour
{
    public static GlobalCache Inst = new GlobalCache();
    public int Gold = 99999;
    public int Gems = 0;
    
    public int Score = 0;
    public int MaxScore = 0;

    public bool BossDefeated = false;
    public float PlayerAngle = 0f;

    public bool IsLoadedMaterials = false;
    public List <Material> ShipMaterials= new List<Material>{};
    public List <int> ShipPrices = new List<int>{0,100,250,500,1000,2500,5000};
    public int ShipBought = 1;
    public int ShipTexture = 0;

            // shop upgrades
    private int shieldUpgradeCount = 0; 
    public int ShieldUpgradeCount {get {return shieldUpgradeCount;} set {shieldUpgradeCount = value;} }

    private int livesUpgradeCount = 0;
    public int LivesUpgradeCount {get {return livesUpgradeCount;} set {livesUpgradeCount = value;} }

    private int weaponUpgradeCount = 0;
    public int WeaponUpgradeCount {get {return weaponUpgradeCount;} set {weaponUpgradeCount = value;} }

    public void SaveData()
    {
        QuickSaveWriter.Create("Player")
            .Write("shieldUpgradeCount", shieldUpgradeCount)
            .Write("livesUpgradeCount", livesUpgradeCount)
            .Write("weaponUpgradeCount", weaponUpgradeCount)
            .Write("MaxScore", MaxScore)
            .Write("ShipBought", ShipBought)
            .Write("ShipTexture", ShipTexture)
            .Write("Coins", Gold)
            .Write("Gems", Gems)
            .Commit();
    }

}
