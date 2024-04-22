using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public RowUI rowUI;
    public ScoreManager scoreManager;
    private void Start()
    {
        //dummy score
        scoreManager.AddScore(new Score("dummy 1", 5));
        scoreManager.AddScore(new Score("another dummy", 91));

        var scores = scoreManager.GetHighScores().ToArray();
        for(int i  = 0; i < scores.Length; i++)
        {
            var row = Instantiate(rowUI, transform).GetComponent<RowUI>();
            row.rank.text = (i + 1).ToString();
            row.name.text = scores[i].name;
            row.score.text = scores[i].score.ToString();
        }
    }
}
