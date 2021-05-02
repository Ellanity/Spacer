using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuMoney : MonoBehaviour
{
    [SerializeField]
    private Text CoinText;
    [SerializeField]
    private Text GemText;
    void Start()
    {
        CoinText.text = "coins - " + GlobalCache.Inst.Gold.ToString();
        GemText.text = "gems - " + GlobalCache.Inst.Gems.ToString(); 
    }
}
