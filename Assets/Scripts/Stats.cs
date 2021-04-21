using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    private int Coins;
    private int Gems;

    [SerializeField]
    private Text CoinsText;
    [SerializeField]
    private Text GemsText;


    public void AddCoin(int Count)
    {
        Coins += Count;
        CoinsText.text = "Coins - " + Coins.ToString();
    }

    public void AddGem(int Count)
    {
        Gems += Count;
        GemsText.text = "Gems - " + Gems.ToString();
    }
}
