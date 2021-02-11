using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Load_Scene : MonoBehaviour
{
    public Button respawn;

    void Start()
    {
        respawn.onClick.AddListener(RespawnOnClick);
    }

    void RespawnOnClick()
    {
        SceneManager.LoadScene(2);
    }
}
