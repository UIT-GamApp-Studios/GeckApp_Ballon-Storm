using TMPro;
using UnityEngine;

public class GameScore : MonoBehaviour
{
    private float CurrentScore;
    public TextMeshProUGUI ScoreText;
    public static GameScore instance;
    private void Awake()
    {
        if (instance == null) { instance = this; }
        else Destroy(gameObject);
    }
    private void Start()
    {
        CurrentScore = 0;
        ScoreText.text = CurrentScore.ToString();
    }
    public void AddScore(float amount)
    {
        CurrentScore += amount;
        ScoreText.text = CurrentScore.ToString();
    }
}
