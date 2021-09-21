using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountMoney : MonoBehaviour
{
    
    [SerializeField]
    private Text CoinText;
    [SerializeField]
    private Text GemText;

    public void UpdateMoneyCounter()
    {
        CoinText.text = GlobalCache.Inst.Gold.ToString();
        GemText.text = GlobalCache.Inst.Gems.ToString(); 
    }
}
