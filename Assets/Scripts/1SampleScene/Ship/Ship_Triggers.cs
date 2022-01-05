    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ship_Triggers : MonoBehaviour
{
    private int _liveUpgrade = GlobalCache.Inst.LivesUpgradeCount / 5;


    [SerializeField] private int HealthPoints = 2;
    private GameObject Shield => transform.GetChild(2).gameObject; 

    [SerializeField] private Text LivesCounter;
    
    [SerializeField] private Stats _Stats;

    [SerializeField] private Score _Score;

    [SerializeField] private List<GameObject> Lives;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "bonus_hp")
        {
            AddHP();
        }
        if (other.tag == "bonus_shield")
        {
            Invulnerability();
        }
        if(other.tag == "coin")
        {
            _Stats.AddCoin((int)1);
        }
        if(other.tag == "gem")
        {
            _Stats.AddGem((int)1);
        }
        if (other.tag == "meteoritecoin")
        {
            other.GetComponent<MoneySpawner>().SpawnMoney();
        }
        if ((other.tag == "meteorite" || other.tag == "meteoritecoin" || other.tag == "enemy" || other.tag == "enemy_bullet" || other.tag == "ray") && (!Shield.activeSelf))
        {
            RemoveHP();
            Invulnerability();
        }
        if(other.tag == "bullet")
            return;
        if(other.tag == "ray" )
            return;
        if(other.tag == "shield")
            return;
        Destroy(other.gameObject);
    } 

    void AddHP()
    {
        if(HealthPoints + _liveUpgrade >= 2)
            return;
        Lives[HealthPoints].SetActive(true);
        HealthPoints++;
        //LivesCounter.text = "x " + HealthPoints.ToString();
    }
    void RemoveHP()
    {
        if(HealthPoints > 0)
        {
            Lives[HealthPoints - 1].SetActive(false);
            HealthPoints--;
            //LivesCounter.text = "x " + HealthPoints.ToString();
        }
        else
        {
            GlobalCache.Inst.Score = _Score._Score;
            Relive();
            //SceneManager.LoadScene(1);
        }
    }
    [SerializeField] private GameObject ReliveMenu;
    [SerializeField] private Button _skip;
    [SerializeField] private Button _gems;
    [SerializeField] private Button _adds;
    [SerializeField] private Text _gemsText;
    [SerializeField] private Text _gemsPrice;
    private int _respawnCounter = 2;
    private int _respawnPrice = 25;
    void Relive()
    {
        Time.timeScale = 0;
        ReliveMenu.SetActive(true);
        _gemsPrice.text = "Pay : " + _respawnPrice.ToString() + " Gems";
        //_respawnPrice *= _respawnCounter;
        _gemsText.text = GlobalCache.Inst.Gems.ToString();
        _skip.onClick.AddListener(Skipped);
        _gems.onClick.AddListener(Payed);
        //_adds.onClick.AddListener(Payed);
    }
    void Payed()
    {
        if(GlobalCache.Inst.Gems < _respawnPrice)
            return;
        GlobalCache.Inst.Gems -= _respawnPrice;
        _respawnPrice *= _respawnCounter;
        AddHP();
        AddHP();
        AddHP();
        Time.timeScale = 1;
        ReliveMenu.SetActive(false);
    }
    void Skipped()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    void Invulnerability()
    {
        Shield.GetComponent<Shield>().TempTime = 0;
        Shield.SetActive(true);
    }
}
