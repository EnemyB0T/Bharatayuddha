using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSpawner : MonoBehaviour
{
    public GameObject[] spawnObjects;
    public Transform[] spawnLocation;
    int rand;
    public int buffsToSpawn;
    List<int> list = new List<int>();

    void Start()
    {
        Spawn();      
        Debug.Log(GameObject.FindGameObjectsWithTag("Buffs").Length);
    }

    // void Update()
    // {
    //     Debug.Log("BuffSpawner Called");
    //     if(GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>()._waveIntervalLeft == GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().waveInterval - 1)
    //     {
    //         GameObject[] gameObjects;
    //         gameObjects = GameObject.FindGameObjectsWithTag("Buffs");
    //         if(gameObjects.Length == 0)
    //         {
    //             Spawn();
    //         }
    //     }
    // }

    public void TrySpawn()
    {
        Debug.Log("TrySpawn Accessed");
        GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag("Buffs");
        Debug.Log(gameObjects.Length);
        if(gameObjects.Length == 1)
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        if(buffsToSpawn > spawnLocation.Length)
        {
            buffsToSpawn = spawnLocation.Length;
        }
        for(int i = 0; i < buffsToSpawn; i++)
        {
            Instantiate(spawnObjects[Random.Range(0,spawnObjects.Length)], spawnLocation[i]);
        }
    }
}
