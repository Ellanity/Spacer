using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuMoney : MonoBehaviour
{
    [SerializeField]
    private Text ScoreText;
    [SerializeField]
    private Text CoinText;
    [SerializeField]
    private Text GemText;
    void Start()
    {
        ScoreText.text = GlobalCache.Inst.MaxScore.ToString();
        CoinText.text = GlobalCache.Inst.Gold.ToString();
        GemText.text = GlobalCache.Inst.Gems.ToString(); 
    }
}
