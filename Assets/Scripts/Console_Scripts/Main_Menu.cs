using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main_Menu : MonoBehaviour
{
    public Button start;
    public Button settings;
    public Button exit;

    void Start()
    {
        start.onClick.AddListener(Start_Game);
        settings.onClick.AddListener(Settings);
        exit.onClick.AddListener(Exit);
    }


    void Start_Game()
    {
        SceneManager.LoadScene(0);
    }

    void Settings()
    {
        SceneManager.LoadScene(3);
    }

    void Exit()
    {
        Application.Quit();
    }
}
