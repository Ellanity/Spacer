using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReturnToMainMenu : MonoBehaviour
{
    [SerializeField]
    private Button _Exit;
    public GameObject _upgr;
    private Button _upgrButton => _upgr.transform.GetChild(3).GetComponent<Button>();
    public GameObject _ship;
    private Button _shipButton => _ship.transform.GetChild(3).GetComponent<Button>();
    public GameObject _terr;
    private Button _terrButton => _terr.transform.GetChild(3).GetComponent<Button>();
    
    void Start()
    {
        _Exit.onClick.AddListener(_ExitClick);
    }
    void _ExitClick()
    {
        if(_upgr.activeSelf)
        {
            _upgrButton.onClick.Invoke();
        }
        else if(_ship.activeSelf)
        {
            _shipButton.onClick.Invoke();
        }
        else if(_terr.activeSelf)
        {
            _terrButton.onClick.Invoke();
        }
        else 
            SceneManager.LoadScene("Main_menu");
    }
}
