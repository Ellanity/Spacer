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


    void Start()
    {
        _Start.onClick.AddListener(_StartClick);
        _Settings.onClick.AddListener(_SettingsClick);
        _Exit.onClick.AddListener(_ExitClick);
    }

    void _StartClick()
    {
        SceneManager.LoadScene(0);
    }

    void _SettingsClick()
    {
        SceneManager.LoadScene(3);
    }

    void _ExitClick()
    {
        Application.Quit();
    }
}
