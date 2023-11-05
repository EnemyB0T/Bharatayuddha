using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyHealth : MonoBehaviour
{
    public GameObject FloatingTextPrefab;

    [SerializeField] public int health = 100;

    [SerializeField] GameObject waveLeft;
    public int MAX_HEALTH = 100;
    [SerializeField] public float exp = 1f;

    EnemySpawner enemySpawner;
    [SerializeField]
    GameObject spawner;

    public static Action OnPlayerDeath;
    public static Action OnEnemyDeath;

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

    public void SetHealth(int maxHealth, int health, float exp)
    {
        this.MAX_HEALTH = maxHealth;
        this.health = health;
        this.exp = exp;
    }

    private IEnumerator VisualIndicator(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void Damage(int amount)
    {
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
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

    public void Heal(int amount)
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
            GameObject.Find("Knight").GetComponent<PlayerHealth>().GainExp(this.exp);

            OnEnemyDeath?.Invoke();
        }
    }
}