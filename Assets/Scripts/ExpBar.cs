using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxExp(int maxExp, int exp)
    {
        slider.maxValue = maxExp;
        slider.value = 0;
    }

    public void SetExp(int exp)
    {
        slider.value = exp;
    }

    public void AddExp(float exp)
    {
        if(slider.value + exp > slider.maxValue)
        {
            float expOver = slider.value + exp - slider.maxValue;
            //level up code here --
            slider.value = expOver;
        }
        else
            slider.value += exp;
    }
}
