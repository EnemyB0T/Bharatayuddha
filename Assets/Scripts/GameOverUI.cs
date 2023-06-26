using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    [SerializeField]
    private Text scoreValueText;

    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        PlayerHealth.OnPlayerDeath += ActivateGameObject;
        EnemyHealth.OnEnemyDeath += CountScore;
        this.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        PlayerHealth.OnPlayerDeath -= ActivateGameObject;
        EnemyHealth.OnEnemyDeath -= CountScore;
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void RetryGame()
    {
        SceneManager.LoadScene(1);
        SceneManager.LoadScene(2);
    }

    private void CountScore()
    {
        score++;
    }

    private void ActivateGameObject()
    {
        this.gameObject.SetActive(true);
        scoreValueText.text = score.ToString();
    }
}
