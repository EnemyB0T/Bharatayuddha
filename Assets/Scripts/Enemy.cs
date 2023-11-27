using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private int damage = 5;
    [SerializeField]
    private float speed = 1.5f;
    [SerializeField]
    private float returnAI = 2f;
    [SerializeField]
    private float remainingTimeToReturnAI;

    [SerializeField]
    private EnemyData data;

    private bool gotHit = false;
    private bool isHit = false;
    private GameObject player;
    
    //comment

    public WaveManager waveManager;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        remainingTimeToReturnAI = returnAI;
        SetEnemyValues();
    }

    // Update is called once per frame
    void Update()
    {
        if((!isHit && !gotHit))
            Swarm();
        else
            ResurrectAI();
        // if(GameObject.Find("Knight") == null)
        // {
        //     Destroy(gameObject);
        // }
    }

    private void SetEnemyValues()
    {
        GetComponent<EnemyHealth>().SetHealth(data.hp, data.hp, data.exp);
        damage = data.damage;
        speed = data.speed;
    }

    private void Swarm()
    {
        if(player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        
    }   

    public void Hit()
    {
        Debug.Log("Hit() accessed");
        this.gotHit = true;
    }

    private void ResurrectAI()
    {
        remainingTimeToReturnAI -= Time.deltaTime;
        if(remainingTimeToReturnAI <= 0)
        {
            isHit = false;
            gotHit = false;
            remainingTimeToReturnAI = returnAI;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(!isHit && !gotHit)
        {
            if (collider.CompareTag("Player"))
            {
                if(collider.GetComponent<PlayerHealth>() != null)
                {
                    collider.GetComponent<PlayerHealth>().Damage(damage);
                    isHit = true;
                    // this.GetComponent<EnemyHealth>().Damage(10000);
                    // opponentController.opponentHasDied();
                }
            }
        }
    }
}