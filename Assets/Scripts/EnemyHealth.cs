using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyHealth : MonoBehaviour
{
    public GameObject FloatingTextPrefab;
    private PlayerHealth playerHealth;
    public CardBuffs cb;

    [SerializeField] public float health = 100;

    [SerializeField] GameObject waveLeft;
    public float MAX_HEALTH = 100;
    [SerializeField] public float exp = 1f;
    public int element = 0;

    EnemySpawner enemySpawner;
    [SerializeField]
    GameObject spawner;

    public static Action OnPlayerDeath;
    public static Action OnEnemyDeath;
    void Start(){
        playerHealth = FindObjectOfType<PlayerHealth>();
        cb = FindObjectOfType<CardBuffs>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            // Damage(10);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            // Heal(10);
        }
    }


    public void SetHealth(int maxHealth, int health, float exp, int element)
    {
        this.MAX_HEALTH = maxHealth;
        this.health = health;
        this.exp = exp;
        this.element = element;
    }

    private IEnumerator VisualIndicator(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void Damage(float amount, int elementalDamage)
    {
        float multiplier = 1f;
        //if weakness
        if ((elementalDamage + 3 + 1)%3 == element)
        {
            multiplier = 2f;
        }
        //if resist
        else if((elementalDamage + 3 - 1)%3 == element)
        {
            multiplier = 0.5f;
        }
        amount *= multiplier;
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }
        if (cb.isLifeSteal()){
            int healInt = Mathf.RoundToInt(amount);

            playerHealth.Heal(healInt);
        }
        this.health -= amount;
        StartCoroutine(VisualIndicator(Color.red));

        if(health <= 0)
        {
            Die();
        }
        if(FloatingTextPrefab && health >= 0)
        {
            var go = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
            go.GetComponent<TextMesh>().text = amount.ToString();
        }
    }

    public void Heal(float amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative healing");
        }

        bool wouldBeOverMaxHealth = health + amount > MAX_HEALTH;
        StartCoroutine(VisualIndicator(Color.green));

        if (wouldBeOverMaxHealth)
        {
            this.health = MAX_HEALTH;
        }
        else
        {
            this.health += amount;
        }
    }

    private void Die()
    {
        Debug.Log("I am Dead!");
        Destroy(gameObject);

        if(this.CompareTag("Player"))
        {
            Time.timeScale = 0;
            OnPlayerDeath?.Invoke();
        }
        else
        {
            GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().enemiesLeft--;
            GameObject.Find("EnemiesKilledValue").GetComponent<ScoreValue>().UpdateScore(1);
            GameObject player;
            player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<PlayerHealth>().GainExp(exp);
            

            OnEnemyDeath?.Invoke();
        }
    }
}