using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // Singleton instance for easy access

    void Awake()
{
    if (instance == null)
    {
        instance = this;
    }
    else
    {
        Destroy(gameObject);
    }
}

    public TMP_Text scoreText; 
    public static int score = 0; 

    void Start()
    {
        UpdateScoreText(); 
    }

    void Update()
    {
        
        UpdateScoreText();
    }

    public void AddScore(int points)
    {
        score += points; 
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString(); 
    }
}
