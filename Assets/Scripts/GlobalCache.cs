using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;
public class GlobalCache//: MonoBehaviour
{
    public static GlobalCache Inst = new GlobalCache();
    public int Gold = 150;
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


    public float SoundLevel;
    //public float MusicLevel;

    private string folderPath;
    private string path;
    public void SaveData()
    {
        folderPath = Application.persistentDataPath + "/MySaveFolder";
        path = Application.persistentDataPath + "/MySaveFolder" + "/Save.txt";
        if(!Directory.Exists(folderPath))
        {
            DirectoryInfo di = Directory.CreateDirectory(folderPath);
        }

        //Debug.Log(path);
        if(!File.Exists(path))
        {
            File.WriteAllText(path, string.Empty);
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine("shieldUpgradeCount " + shieldUpgradeCount.ToString());
                sw.WriteLine("livesUpgradeCount " + shieldUpgradeCount.ToString());
                sw.WriteLine("weaponUpgradeCount " + weaponUpgradeCount.ToString());
                sw.WriteLine("MaxScore " + MaxScore.ToString());
                sw.WriteLine("ShipBought " + ShipBought.ToString());
                sw.WriteLine("ShipTexture " + ShipTexture.ToString());
                sw.WriteLine("Coins " + Gold.ToString());
                sw.WriteLine("Gems " + Gems.ToString());
                sw.WriteLine("SoundLevel " + SoundLevel.ToString());
                //sw.WriteLine("MusicLevel " + MusicLevel.ToString());
            }
        }
        else
        {
            using StreamWriter sw = new StreamWriter(path);
            {
                sw.WriteLine("shieldUpgradeCount " + shieldUpgradeCount.ToString());
                sw.WriteLine("livesUpgradeCount " + shieldUpgradeCount.ToString());
                sw.WriteLine("weaponUpgradeCount " + weaponUpgradeCount.ToString());
                sw.WriteLine("MaxScore " + MaxScore.ToString());
                sw.WriteLine("ShipBought " + ShipBought.ToString());
                sw.WriteLine("ShipTexture " + ShipTexture.ToString());
                sw.WriteLine("Coins " + Gold.ToString());
                sw.WriteLine("Gems " + Gems.ToString());
                sw.WriteLine("SoundLevel " + SoundLevel.ToString());
                //sw.WriteLine("MusicLevel " + MusicLevel.ToString());
            }
        }
    }
    public void LoadData()
    {
        folderPath = Application.persistentDataPath + "/MySaveFolder";
        path = Application.persistentDataPath + "/MySaveFolder" + "/Save.txt";
        if(!File.Exists(path))
            SaveData();
        using (StreamReader sr = new StreamReader(path))
        {
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                int SpacePosition = s.IndexOf(" ", 0);
                string Name = s.Substring(0, SpacePosition);
                string Count = s.Substring(SpacePosition + 1);
                if(Name == "shieldUpgradeCount")
                    shieldUpgradeCount = int.Parse(Count);
                if(Name == "livesUpgradeCount")
                    livesUpgradeCount = int.Parse(Count);
                if(Name == "weaponUpgradeCount")
                    weaponUpgradeCount = int.Parse(Count);
                if(Name == "MaxScore")
                    MaxScore = int.Parse(Count);
                if(Name == "ShipBought")
                    ShipBought = int.Parse(Count);
                if(Name == "ShipTexture")
                    ShipTexture = int.Parse(Count);
                if(Name == "Coins")
                    Gold = int.Parse(Count);
                if(Name == "Gems")
                    Gems = int.Parse(Count);
                if(Name == "SoundLevel")
                    SoundLevel = float.Parse(Count);
                //if(Name == "MusicLevel")
                //    MusicLevel = float.Parse(Count);
            }
        }
    }
}
