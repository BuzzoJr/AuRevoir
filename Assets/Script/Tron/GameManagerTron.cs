using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerTron : MonoBehaviour
{
    public PlayerControllerTron player;
    public AIControllerTron ai;
    public TMP_Text scoreText;

    private int score;
    private float timeSurvived;

    void Start()
    {
        score = 0;
        timeSurvived = 0f;
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Time.timeScale > 0)
        {
            timeSurvived += Time.deltaTime;
            score = Mathf.FloorToInt(timeSurvived);
            scoreText.text = "Score: " + score;
        }
    }

    public void AddPointsForKillingAI()
    {
        score += 10;
    }

    public void NextLevel()
    {
        player.moveSpeed += 2f;
        ai.moveSpeed += 2f;
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        Debug.Log("Fim de jogo! Pontuação final: " + score);
    }
}
