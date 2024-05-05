using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreValue : MonoBehaviour
{
    
    public static ScoreValue instance;
    [SerializeField]
    public TextMeshProUGUI scoreText;
    
    public int score;

private Waves w;
private WaveManager wm;
private int wave = 2;
private int totalEnemy;
private int wave4;
private int wave5;
private int wave6;
private int wave7;
private int wave8;
private int wave9;
private int wave10;
private int StageDone;
private BuffMenu bm;
    void Start(){
w = FindObjectOfType<Waves>();
wm = FindObjectOfType<WaveManager>();
 bm = FindObjectOfType<BuffMenu>();
    }

    // Start is called before the first frame update
    
    public void UpdateScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
        
        //wave 2 starts
      
        if (score == wm.Wave1TotalEnemy){
            w.Wave2();
            //bm.WinUIActivate();
            wm.WaveText.text = "Wave 2";
            totalEnemy = wm.Wave1TotalEnemy + wm.Wave2TotalEnemy;
            //wave++;
        }
         else if (score == totalEnemy){
            StartCoroutine(w.Wave3());
            wm.WaveText.text = "Wave 3";
            wave4 = totalEnemy + wm.Wave3TotalEnemy;
        }
         else if (score == wave4){
            
            StartCoroutine(w.Wave4());
            wm.WaveText.text = "Wave 4";
            wave5 = wave4 + wm.Wave4TotalEnemy;
        }
         else if (score == wave5){
            StartCoroutine(w.Wave5());
            wm.WaveText.text = "Wave 5";
            wave6 = wave5 + wm.Wave5TotalEnemy;
        }
          else if (score == wave6){
            StartCoroutine(w.Wave6());
            wm.WaveText.text = "Wave 6";
            wave7 = wave6 + wm.Wave6TotalEnemy;
        }
          else if (score == wave7){
            StartCoroutine(w.Wave7());
            wm.WaveText.text = "Wave 7";
            wave8 = wave7 + wm.Wave7TotalEnemy;
        }
          else if (score == wave8){
            StartCoroutine(w.Wave8());
            wm.WaveText.text = "Wave 8";
            wave9 = wave8 + wm.Wave8TotalEnemy;
        }
          else if (score == wave9){
            StartCoroutine(w.Wave9());
            wm.WaveText.text = "Wave 9";
            wave10 = wave9 + wm.Wave9TotalEnemy;
        }
          else if (score == wave10){
            StartCoroutine(w.Wave10());
            wm.WaveText.text = "Wave 10";
            StageDone=wave10 + wm.Wave10TotalEnemy;
        }
         else if (score == StageDone){
      
            bm.WinUIActivate();

        }
    }

    public void Deactivate()
    {
        this.gameObject.SetActive(false);
    }

}
