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
        GlobalCache.Inst.LoadData();
        ScoreText.text = GlobalCache.Inst.MaxScore.ToString();
        CoinText.text = GlobalCache.Inst.Gold.ToString();
        GemText.text = GlobalCache.Inst.Gems.ToString(); 
    }
}
