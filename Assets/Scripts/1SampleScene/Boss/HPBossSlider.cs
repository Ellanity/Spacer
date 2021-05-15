using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBossSlider : MonoBehaviour
{
    public Slider slider => GetComponent<Slider>();
    
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void AddHealth(int health)
    {
        slider.value += health;
    }
}
