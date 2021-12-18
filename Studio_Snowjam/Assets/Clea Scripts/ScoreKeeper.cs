using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private int scoreAmount;
    private Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + scoreAmount;
    }
    
    public void AddScore(int score)
    {
        scoreAmount += score;
    }

    public void SubScore(int score)
    {
        AddScore(-score);
    }
}
