using System.Collections;
using System.Collections.Generic;
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
        SceneManager.LoadScene("Main_menu");
    }
}
