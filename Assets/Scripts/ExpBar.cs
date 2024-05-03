using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    public Slider slider;
    public int accumulatedLevel = 0;


    //Stats to be buffed
    public PlayerHealth playerHealth;
    public AttackArea attackArea;
    public List<DendroAttack> dendroAttacks = new List<DendroAttack>();
    public int levelUpIncreaseDamage = 1;
    public int levelUpIncreaseHealth = 10;
    public float levelUpIncreaseAoE = 0.2f;
    public ArrowData arrow;
    public FireAoEFriendly fAoE;


    public void SetMaxExp(int maxExp, int exp)
    {
        slider.maxValue = maxExp;
        slider.value = exp;
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
            
            slider.value = expOver;
            accumulatedLevel++;
            
            //level up code here --
            attackArea.damage += levelUpIncreaseDamage;
            foreach(DendroAttack attack in dendroAttacks)
                attack.damage += levelUpIncreaseDamage;
            fAoE.damageOverTime += levelUpIncreaseAoE;
            playerHealth.SetHealth(playerHealth.health + levelUpIncreaseHealth, playerHealth.health);
            arrow.damage += levelUpIncreaseDamage;

        }
        else
            slider.value += exp;
    }
}
