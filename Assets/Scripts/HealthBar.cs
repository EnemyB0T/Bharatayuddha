using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(int maxHealth, int health)
    {
        slider.maxValue = maxHealth;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
