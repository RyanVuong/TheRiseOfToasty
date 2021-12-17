using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
   [SerializeField] private int curScore;
   private Text scoreText;

    public void addScore(int score)
    {
        curScore += score;
    }

    public void subScore(int score)
    {
        addScore(-score);
    }

    

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        curScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + curScore;
    }
}
