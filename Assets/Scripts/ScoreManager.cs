using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private int score = 0;

    [SerializeField]
    private Text scoreText;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ClearScore()
    {
        score = 0;
        RenderScore();
    }

    public void AddScore(int value)
    {
        score += value;
        RenderScore();
    }

    public int GetScore() => score;

    void RenderScore()
    {
        if (!scoreText) return;
        scoreText.text = "Score: " + score;
    }
}
