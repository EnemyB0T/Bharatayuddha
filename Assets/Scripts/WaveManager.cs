using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WaveManager : MonoBehaviour
{
    public int enemyCount = 0;
    public TextMeshProUGUI WaveText;
    public GameObject BuffMenu;

    //wave 1
    public int Wave1TotalEnemy;
    public int Wave1EnemyID;
    public int Wave1EnemyCount;
    //wave 2
    public int Wave2TotalEnemy;
    public int Wave2EnemyID;
    public int Wave2EnemyCount;
    //wave 3
    public int Wave3TotalEnemy;
    public int Wave3EnemyID;
    public int Wave3EnemyCount;
    public int Wave3EnemyID2;
    public int Wave3EnemyCount2;
    //wave 4
    public int Wave4TotalEnemy;
    public int Wave4EnemyID;
    public int Wave4EnemyCount;
    public int Wave4EnemyID2;
    public int Wave4EnemyCount2;

    //wave 5
    public int Wave5TotalEnemy;
    public int Wave5EnemyID;
    public int Wave5EnemyCount;
    public int Wave5EnemyID2;
    public int Wave5EnemyCount2;
    public int Wave5EnemyID3;
    public int Wave5EnemyCount3;

    //wave 6
    public int Wave6TotalEnemy;
    public int Wave6EnemyID;
    public int Wave6EnemyCount;
    public int Wave6EnemyID2;
    public int Wave6EnemyCount2;
    public int Wave6EnemyID3;
    public int Wave6EnemyCount3;
    
    //wave 7
    public int Wave7TotalEnemy;
    public int Wave7EnemyID;
    public int Wave7EnemyCount;
    public int Wave7EnemyID2;
    public int Wave7EnemyCount2;
    public int Wave7EnemyID3;
    public int Wave7EnemyCount3;

    //wave 8
    public int Wave8TotalEnemy;
    public int Wave8EnemyID;
    public int Wave8EnemyCount;
    public int Wave8EnemyID2;
    public int Wave8EnemyCount2;
    public int Wave8EnemyID3;
    public int Wave8EnemyCount3;

    //wave 9
    public int Wave9TotalEnemy;
    public int Wave9EnemyID;
    public int Wave9EnemyCount;
    public int Wave9EnemyID2;
    public int Wave9EnemyCount2;
    public int Wave9EnemyID3;
    public int Wave9EnemyCount3;

    //wave 10
    public int Wave10TotalEnemy;
    public int Wave10EnemyID;
    public int Wave10EnemyCount;
    public int Wave10EnemyID2;
    public int Wave10EnemyCount2;
    public int Wave10EnemyID3;
    public int Wave10EnemyCount3;


    public void AddEnemy()
    {
        enemyCount++;
    }
    public void RemoveEnemy()
    {
        enemyCount--;
    }
    
}
