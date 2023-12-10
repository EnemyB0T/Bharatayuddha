using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    private bool isPlayer1;

    [SerializeField]
    private EnemyData data;

    private bool gotHit = false;
    private bool isHit = false;
    private GameObject[] player;
    private int playerIndex;
    
    //comment

    public WaveManager waveManager;

    // Start is called before the first frame update
    void Start()
    {
        isPlayer1 = (Random.value < 0.5f);
        player = GameObject.FindGameObjectsWithTag("Player");
        playerIndex = Random.Range(0, player.Length);
        remainingTimeToReturnAI = returnAI;
        SetEnemyValues();
    }

    // Update is called once per frame
    void Update()
    {
        if ((!isHit && !gotHit))
        {
            Swarm(player[playerIndex]);
        }
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

    private void Swarm(GameObject player)
    {
        if(player != null)
        {
            if (Random.Range(1, 0) == 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }
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