using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public int health = 100;
    public int shield = 0;

    public int currentHealth = 100;
    public int buffedHealth = 100;

    public int currentExp = 0;
    public int maxExp = 10;
    public int currentLevel = 0;

    private int fibonacci = 1;

    public static Action OnPlayerDeath;
    public static Action OnEnemyDeath;

    Color color;

    public HealthBar healthBar;
    public ExpBar expBar;
    public PlayerStatsValue stats;
    public HealthValue healthValue;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Damage(10);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            GainExp(10);
        }

        if(shield > 0)
        {
            stats.ActivateShield();
        }
        else
        {
            stats.DeactivateShield();
        }
    }

    public void SetHealth(int maxHealth, int health)
    {
        this.currentHealth = maxHealth;
        this.health = health;
        healthBar.SetMaxHealth(maxHealth, health);
    }

    public void SetExp(int maxExp, int currentExp)
    {
        expBar.SetMaxExp(maxExp, currentExp);
    }

    private IEnumerator VisualIndicator(Color colorTarget, Color colorBase)
    {
        GetComponent<SpriteRenderer>().color = colorTarget;
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().color = colorBase;
    }

    public void Damage(int amount)
    {
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }

        if(shield > 0 && shield - amount > 0)
        {
            this.shield -= amount;
            if(ColorUtility.TryParseHtmlString("#FFFF9F", out color))
            {
                this.GetComponent<SpriteRenderer>().color = color;
                StartCoroutine(VisualIndicator(Color.red, color));
            }
        }
        else if(shield > 0 && shield - amount <= 0)
        {
            int temp = amount - shield;
            shield = 0;


            this.health -= temp;
            StartCoroutine(VisualIndicator(Color.red, Color.white));
            healthBar.SetHealth(health);
        }
        else
        {
            this.health -= amount;
            StartCoroutine(VisualIndicator(Color.red, Color.white));
            healthBar.SetHealth(health);
        }
        
        healthValue.UpdateHealth();

        if(health <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative healing");
        }


        if(buffedHealth != currentHealth)
        {
            currentHealth = buffedHealth;
            healthBar.SetMaxHealth(currentHealth, health+amount);
        }
        else
        {
            healthBar.SetHealth(amount+health);
        }


        bool wouldBeOverMaxHealth = health + amount > currentHealth;
        StartCoroutine(VisualIndicator(Color.green, Color.white));
        
        if (wouldBeOverMaxHealth)
        {
            this.health = currentHealth;
        }
        else
        {
            this.health += amount;
        }

        healthValue.UpdateHealth();
    }

    public void GainExp(float acquiredExp)
    {
        currentExp += Mathf.RoundToInt(acquiredExp);
        Debug.Log("accessed GainExp");
        expBar.AddExp(acquiredExp);
        Debug.Log("Added Exp");
        if (currentExp >= maxExp)
        {
            int temp = currentExp - maxExp;
            maxExp += Fibonacchi(fibonacci++);
            Debug.Log(maxExp);
            expBar.SetMaxExp(maxExp, temp);
            currentExp = temp;
        }
        
    }

    private int Fibonacchi(int fib)
    {
        int a = 1, b = 1, c = 0;
        for(int i = 2; i < fib+2; i++)
        {
            c = a + b;
            a = b;
            b = c;
        }
        Debug.Log(c);
        return c;
        
    }

    private void Die()
    {
        Debug.Log("I am Dead!");
        Destroy(gameObject);

        if(this.CompareTag("Player"))
        {
            GameObject.Find("EnemiesKilledValue").GetComponent<ScoreValue>().Deactivate();

            Time.timeScale = 0;
            OnPlayerDeath?.Invoke();
        }
        else
        {
            OnEnemyDeath?.Invoke();
        }
    }
}