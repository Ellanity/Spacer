    using CI.QuickSave;
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
        LoadSave();
        ScoreText.text = GlobalCache.Inst.MaxScore.ToString();
        CoinText.text = GlobalCache.Inst.Gold.ToString();
        GemText.text = GlobalCache.Inst.Gems.ToString(); 
    }
    void LoadSave()
    {
        //Debug.Log(Application.persistentDataPath);
        QuickSaveWriter writer = QuickSaveWriter.Create("Player");
        writer.Commit();
        //QuickSaveReader reader = QuickSaveReader.Create("Player");
        int result = 0;
        QuickSaveReader.Create("Player").TryRead<int>("Score", out result);
        //Debug.Log(result);
        if(result > 0)
        {
            QuickSaveReader.Create("Player").Read<int>("Score", r => GlobalCache.Inst.MaxScore = r);
            QuickSaveReader.Create("Player").Read<int>("Coins", r => GlobalCache.Inst.Gold = r);
            QuickSaveReader.Create("Player").Read<int>("Gems", r => GlobalCache.Inst.Gems = r);
            QuickSaveReader.Create("Player").Read<int>("ShipBought", r => GlobalCache.Inst.ShipBought = r);
            QuickSaveReader.Create("Player").Read<int>("ShipTexture", r => GlobalCache.Inst.ShipTexture = r);
        }
    }
}
