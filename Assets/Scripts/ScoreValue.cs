using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreValue : MonoBehaviour
{
    
    public static ScoreValue instance;
    [SerializeField]
    public TextMeshProUGUI scoreText;
    
    public  int score = 0;

    // Start is called before the first frame update
    
    public void UpdateScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
    }

    public void Deactivate()
    {
        this.gameObject.SetActive(false);
    }

}
