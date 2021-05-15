    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTriggers : MonoBehaviour
{
    [SerializeField]
    public int BossHp = 25;
    public GameObject SliderBoss;
    void Start()
    {
        SliderBoss = GameObject.FindWithTag("SliderHp");
        //SliderBoss.SetActive(true);
        SliderBoss.GetComponent<HPBossSlider>().SetMaxHealth(BossHp);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "bullet")
        {
            BossHp--;
            SliderBoss.GetComponent<HPBossSlider>().AddHealth(-1);
            if(BossHp <= 0)
                BossDestroy();
            Destroy(other.gameObject); 
        }
    }
    void BossDestroy()
    {
        GlobalCache.Inst.BossDefeated = true;
        //SliderBoss.SetActive(false);
        Destroy(gameObject);
    }
}
