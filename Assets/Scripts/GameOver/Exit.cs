using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Exit : MonoBehaviour
{
    public void _ExitClick()
    {
        GlobalCache.Inst.SaveData();
        SceneManager.LoadScene("Main_menu");
    }
}
