using CI.QuickSave;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPrefab : MonoBehaviour
{
    //[SerializeField]
    //private List <Button> Buttons;
    [SerializeField]
    private List <Text> Texts;
    //[SerializeField]
    //private List <int> Prices;
    [SerializeField]
    private GameObject NotEnough;

    void Start()
    {
        CheckPurchased();
        GetComponent<CountMoney>().UpdateMoneyCounter();
        //return;
        for(int i = 0; i < Texts.Count; i++)
        {
            int Check = 1<<i;
            int GlobalCheck = GlobalCache.Inst.ShipBought;
            int Result = Check&GlobalCheck;
            if(Result > 0)
            {
                Texts[i].text = "purchased";
                Texts[i].color = Color.green;
            }
        }
        Texts[GlobalCache.Inst.ShipTexture].text = "equipped";
    }

    public void PrefabClick0(int number)
    {
        int Check = 1<<number;
        int GlobalCheck = GlobalCache.Inst.ShipBought;
        int Result = Check&GlobalCheck;
        if(Result > 0)
        {
            Texts[GlobalCache.Inst.ShipTexture].text = "purchased";
            GlobalCache.Inst.ShipTexture = number;
            Texts[number].text = "equipped";
        }
        else
        {
            int Coins = GlobalCache.Inst.Gold;
            if(Coins >= GlobalCache.Inst.ShipPrices[number])
            {
                GlobalCache.Inst.ShipBought += Check;

                //Debug.Log(GlobalCache.Inst.Gold);
                GlobalCache.Inst.Gold -= GlobalCache.Inst.ShipPrices[number];
                GetComponent<CountMoney>().UpdateMoneyCounter();
                Debug.Log(GlobalCache.Inst.Gold);
                
                
                Texts[GlobalCache.Inst.ShipTexture].text = "purchased";
                GlobalCache.Inst.ShipTexture = number;
                Texts[number].color = Color.green;
                Texts[number].text = "equipped";
            }
            else 
            {
                NotEnough.GetComponent<NotEnough>().enabled = true;
                NotEnough.GetComponent<NotEnough>().SetTrue();
            }
        }
        GlobalCache.Inst.SaveData();
        
    }
    void CheckPurchased()
    {
        int result = 0;
        QuickSaveReader.Create("Player").TryRead<int>("ShipBought", out result);
        //Debug.Log(result);
        if(result > 0)
        {
            QuickSaveReader.Create("Player").Read<int>("ShipBought", r => GlobalCache.Inst.ShipBought = r);
            QuickSaveReader.Create("Player").Read<int>("ShipTexture", r => GlobalCache.Inst.ShipTexture = r);
        }
    }
    
}
