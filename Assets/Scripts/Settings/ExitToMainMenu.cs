using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ExitToMainMenu : MonoBehaviour
{
    [SerializeField]
    private Button _MainMenu;


    void Start()
    {
        _MainMenu.onClick.AddListener(_MainMenuClick);
    }

    void _MainMenuClick()
    {
        SceneManager.LoadScene("Main_menu");
    }
}
