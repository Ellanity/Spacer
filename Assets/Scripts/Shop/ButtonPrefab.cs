    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPrefab : MonoBehaviour
{
    [SerializeField]
    private List <Button> Buttons;
    [SerializeField]
    private List <Text> Texts;
    [SerializeField]
    private List <int> Prices;
    [SerializeField]
    private GameObject NotEnough;

    void Start()
    {
        GetComponent<CountMoney>().UpdateMoneyCounter();
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

        Buttons[0].onClick.AddListener(delegate{PrefabClick0(0);});
        Buttons[1].onClick.AddListener(delegate{PrefabClick0(1);});
        Buttons[2].onClick.AddListener(delegate{PrefabClick0(2);});
        Buttons[3].onClick.AddListener(delegate{PrefabClick0(3);});
        Buttons[4].onClick.AddListener(delegate{PrefabClick0(4);});
        Buttons[5].onClick.AddListener(delegate{PrefabClick0(5);});
    }

    void PrefabClick0(int temp)
    {
        int Check = 1<<temp;
        int GlobalCheck = GlobalCache.Inst.ShipBought;
        int Result = Check&GlobalCheck;
        if(Result > 0)
        {
            Texts[GlobalCache.Inst.ShipTexture].text = "purchased";
            GlobalCache.Inst.ShipTexture = temp;
            Texts[temp].text = "equipped";
        }
        else
        {
            int Coins = GlobalCache.Inst.Gold;
            if(Coins > Prices[temp])
            {
                GlobalCache.Inst.ShipBought += Check;

                GlobalCache.Inst.Gold -= Prices[temp];
                GetComponent<CountMoney>().UpdateMoneyCounter();
                
                
                Texts[GlobalCache.Inst.ShipTexture].text = "purchased";
                GlobalCache.Inst.ShipTexture = temp;
                Texts[temp].color = Color.green;
                Texts[temp].text = "equipped";
            }
            else 
            {
                NotEnough.GetComponent<NotEnough>().enabled = true;
                NotEnough.GetComponent<NotEnough>().TempTime = 0f;
                NotEnough.GetComponent<Text>().color = new Color(1,0,0,1);
            }
        }
    }
}
