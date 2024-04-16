using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Waves : MonoBehaviour
{

    private WaveManager wm;
    private ScoreValue sv;
    private EnemySpawner es;
    // Start is called before the first frame update
    void Start()
    {
        wm = FindObjectOfType<WaveManager>();
        sv = FindObjectOfType<ScoreValue>();
        es = FindObjectOfType<EnemySpawner>();
         es.waveValue = es.currWave * es.waveMultiplier;
        es.SpawnEnemy(wm.Wave1EnemyID, wm.Wave1EnemyCount);
        wm.WaveText.text = "Wave 1";
        es.wave = 1;
    }

   
       
    

public void Wave2(){
    es.SpawnEnemy(wm.Wave2EnemyID, wm.Wave2EnemyCount);
}

public IEnumerator Wave3(){
    es.SpawnEnemy(wm.Wave3EnemyID, wm.Wave3EnemyCount);
   yield return new WaitForSeconds(5f);
    es.SpawnEnemy2(wm.Wave3EnemyID2, wm.Wave3EnemyCount2);
}

public IEnumerator Wave4(){
    es.SpawnEnemy(wm.Wave4EnemyID, wm.Wave4EnemyCount);
   yield return new WaitForSeconds(5f);
    es.SpawnEnemy2(wm.Wave4EnemyID2, wm.Wave4EnemyCount2);
}
public IEnumerator Wave5(){
    es.SpawnEnemy(wm.Wave5EnemyID, wm.Wave5EnemyCount);
   yield return new WaitForSeconds(5f);
    es.SpawnEnemy2(wm.Wave5EnemyID2, wm.Wave5EnemyCount2);
    yield return new WaitForSeconds(5f);
    es.SpawnEnemy3(wm.Wave5EnemyID3, wm.Wave5EnemyCount3);
}

public IEnumerator Wave6(){
    es.SpawnEnemy(wm.Wave6EnemyID, wm.Wave6EnemyCount);
   yield return new WaitForSeconds(5f);
    es.SpawnEnemy2(wm.Wave6EnemyID2, wm.Wave6EnemyCount2);
    yield return new WaitForSeconds(5f);
    es.SpawnEnemy3(wm.Wave6EnemyID3, wm.Wave6EnemyCount3);
}

public IEnumerator Wave7(){
    es.SpawnEnemy(wm.Wave7EnemyID, wm.Wave7EnemyCount);
   yield return new WaitForSeconds(5f);
    es.SpawnEnemy2(wm.Wave7EnemyID2, wm.Wave7EnemyCount2);
    yield return new WaitForSeconds(5f);
    es.SpawnEnemy3(wm.Wave7EnemyID3, wm.Wave7EnemyCount3);
}

public IEnumerator Wave8(){
    es.SpawnEnemy(wm.Wave8EnemyID, wm.Wave8EnemyCount);
   yield return new WaitForSeconds(5f);
    es.SpawnEnemy2(wm.Wave8EnemyID2, wm.Wave8EnemyCount2);
    yield return new WaitForSeconds(5f);
    es.SpawnEnemy3(wm.Wave8EnemyID3, wm.Wave8EnemyCount3);
}

public IEnumerator Wave9(){
    es.SpawnEnemy(wm.Wave9EnemyID, wm.Wave9EnemyCount);
   yield return new WaitForSeconds(5f);
    es.SpawnEnemy2(wm.Wave9EnemyID2, wm.Wave9EnemyCount2);
    yield return new WaitForSeconds(5f);
    es.SpawnEnemy3(wm.Wave9EnemyID3, wm.Wave9EnemyCount3);
}

public IEnumerator Wave10(){
    es.SpawnEnemy(wm.Wave10EnemyID, wm.Wave10EnemyCount);
   yield return new WaitForSeconds(5f);
    es.SpawnEnemy2(wm.Wave10EnemyID2, wm.Wave10EnemyCount2);
    yield return new WaitForSeconds(5f);
    es.SpawnEnemy3(wm.Wave10EnemyID3, wm.Wave10EnemyCount3);
}
    }
    
    





