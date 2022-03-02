using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField]
    private Button _Start;
    [SerializeField]
    private Button _Settings;
    [SerializeField]
    private Button _Exit;
    [SerializeField]
    private Button _Shop;


    void Start()
    {   
        _Start.onClick.AddListener(_StartClick);
        _Settings.onClick.AddListener(_SettingsClick);
        //_Exit.onClick.AddListener(_ExitClick);
        _Shop.onClick.AddListener(_ShopClick);
        //Debug.Log(Application.persistentDataPath);
    }

    void _StartClick()
    {
        SceneManager.LoadScene("SampleScene");
    }

    void _SettingsClick()
    {
        //GlobalCache.Inst.SaveData();
        SceneManager.LoadScene("Settings");
    }

    /*void _ExitClick()
    {
        Application.Quit();
    }*/

    void _ShopClick()
    {
        //GlobalCache.Inst.LoadData();
        SceneManager.LoadScene("Shop");
    }
}
