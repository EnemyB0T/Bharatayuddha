using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //test
    public List<Enemies> enemies = new List<Enemies>();
    public int currWave;
    public int waveValue;
    public List<GameObject> enemiesToSpawn = new List<GameObject>();
    public Transform[] spawnLocation;
    public int waveDuration;
    public int waveMultiplier;
    private float waveTimer;
    private float spawnInterval;
    private float spawnTimer;

    [SerializeField]
    public int enemiesLeft = 0;

    bool killedAllEnemies = false;
    [SerializeField]
    public float waveInterval = 5;
    public float _waveIntervalLeft;


    //Fibonacchi Sequence cuz why not? :)
    private int prevprevFib = 0;
    private int prevFib = 1;
    private int currFib = 1;



    // Start is called before the first frame update
    void Start()
    {
        GenerateWave();
        _waveIntervalLeft = waveInterval;
    }

    void FixedUpdate() {

        if(spawnTimer <= 0)
        {
            if(enemiesToSpawn.Count >0)
            {
                Instantiate(enemiesToSpawn[0], spawnLocation[Random.Range(0,spawnLocation.Length)].position, Quaternion.identity);
                enemiesToSpawn.RemoveAt(0);
                spawnTimer = spawnInterval;
            }
            else
            {
                waveTimer = 0;
            }
        }
        else
        {
            spawnTimer-= Time.fixedDeltaTime;
            waveTimer-=Time.fixedDeltaTime;
        }
        //If there is no enemy left
        if(enemiesLeft <= 0)
        {
            //If break time still in progress
            if(_waveIntervalLeft >= 0)
            {
                _waveIntervalLeft -= Time.fixedDeltaTime;
                if(_waveIntervalLeft < waveInterval - 0.5f && _waveIntervalLeft > waveInterval - 1f)
                {
                    GameObject.Find("BuffSpawner").GetComponent<BuffSpawner>().TrySpawn();
                    Debug.Log("attempted to spawn buff");
                }
            }
            //Spawn the next wave
            else
            {
                _waveIntervalLeft = waveInterval; //reset break time
                currWave++; //increase wave
                waveDuration += currFib; //increase enemy count
                prevprevFib = prevFib;
                prevFib = currFib;
                currFib = prevprevFib + prevFib;
                GenerateWave();
            }
        }
    }

    public void GenerateWave()
    {
        waveValue = currWave * waveMultiplier;
        GenerateEnemies();

        spawnInterval = waveDuration/enemiesToSpawn.Count;
        waveTimer = waveDuration;
    }
    public void GenerateEnemies()
    {
        List<GameObject> generatedEnemies = new List<GameObject>();
        while(waveValue>0)
        {
            int randEnemyId = Random.Range(0, enemies.Count);
            int randEnemyCost = enemies[randEnemyId].cost;

            if(waveValue-randEnemyCost>=0)
            {
                generatedEnemies.Add(enemies[randEnemyId].enemyPrefab);
                waveValue -= randEnemyCost;
            }
            else if(waveValue <= 0)
            {
                break;
            }
        }
        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;
        enemiesLeft = enemiesToSpawn.Count;
    }
}

[System.Serializable]
public class Enemies
{
    public GameObject enemyPrefab;
    public int cost;
}
