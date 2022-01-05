using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUpgradeButton : MonoBehaviour
{
    [SerializeField] private List <int> _prices;
    [SerializeField] private List <GameObject> _points;
    [SerializeField] private CountMoney _refreshMoney;
    [SerializeField] private NotEnough _notEnough;
    [SerializeField] private NotEnough _maxLevel;
    [SerializeField] private Text _price;
    private int _curLevel = 0;
    private Button _button => GetComponent<Button>();
    void Start()
    {
        _curLevel = GlobalCache.Inst.LivesUpgradeCount;
        _button.onClick.AddListener(AddLevel);
        CheckPurchased();   
    }
    void AddLevel()
    {
        if(_curLevel >= 10)
        {
            _maxLevel.enabled = true;
            _maxLevel.SetTrue();
            return;
        }
        ref int _coins = ref GlobalCache.Inst.Gold;
        if(_prices[_curLevel] > _coins)
        {
            _notEnough.enabled = true;
            _notEnough.SetTrue();
            return;
        }
        _coins -= _prices[_curLevel];
        _curLevel++;
        GlobalCache.Inst.LivesUpgradeCount += 1;
        _refreshMoney.UpdateMoneyCounter();
        CheckPurchased();
        GlobalCache.Inst.SaveData();
    }
    private int lastLvl = 0;
    void CheckPurchased()
    {
        for(int i = lastLvl; i < Mathf.Min(10,_curLevel); i++)
        {
            GameObject before = _points[i].transform.GetChild(0).gameObject;
            GameObject after = _points[i].transform.GetChild(1).gameObject;
            after.SetActive(true);
            before.SetActive(false);
        }
        lastLvl = _curLevel;
        SetPrice();
    }
    void SetPrice()
    {
        if(_curLevel >= 10)
        {
            _price.text = "max level ";
            return;
        }
        _price.text = _prices[_curLevel].ToString() + " gems ";
    }
}
