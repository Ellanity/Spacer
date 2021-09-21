using CI.QuickSave;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Exit : MonoBehaviour
{
    [SerializeField]
    private Button _Exit;
    void Start()
    {
        _Exit.onClick.AddListener(_ExitClick);
    }
    void _ExitClick()
    {
        QuickSaveWriter.Create("Player")
            .Write("Score", GlobalCache.Inst.MaxScore)
            .Write("Coins", GlobalCache.Inst.Gold)
            .Write("Gems", GlobalCache.Inst.Gems)
            .Commit();
        SceneManager.LoadScene("Main_menu");
    }
}
