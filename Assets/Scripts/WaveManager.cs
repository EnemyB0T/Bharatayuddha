using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int enemyCount = 0;

    public void AddEnemy()
    {
        enemyCount++;
    }
    public void RemoveEnemy()
    {
        enemyCount--;
    }
    
}
