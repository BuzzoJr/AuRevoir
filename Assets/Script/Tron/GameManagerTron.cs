using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerTron : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public PlayerControllerTron player;
    public AIControllerTron ai;
    public TMP_Text scoreText;
    public TMP_Text status;

    private int score;
    private float timeSurvived;
    private Vector3 initPlayer;
    private Vector3 initEnemy;
    private float initPlayerSpeed;
    private float initEnemySpeed;
    private float dificultyIncrementSpeed = 2;

    private bool playing = true;

    void Start()
    {
        initPlayer = player.transform.position;
        initEnemy = ai.transform.position;
        score = 0;
        timeSurvived = 0f;

        initPlayerSpeed = player.moveSpeed;
        initEnemySpeed = ai.moveSpeed;
    }

    void Update()
    {
        if (playing)
        {
            status.text = "";
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
        playing = true;

        // Destroy the current player and AI game objects
        Destroy(player.gameObject);
        Destroy(ai.gameObject);

        // Instantiate new Player and AI in this object's position
        GameObject newPlayer = Instantiate(playerPrefab, initPlayer, Quaternion.identity, transform);
        GameObject newAI = Instantiate(enemyPrefab, initEnemy, Quaternion.identity, transform);

        // Reference the new player and AI to the variables
        player = newPlayer.GetComponent<PlayerControllerTron>();
        player.gameManager = this;
        ai = newAI.GetComponent<AIControllerTron>();
        ai.gameManager = this;
        ai.player = player.transform;
        player.ai = ai;

        // Reset their speeds to initial values
        player.moveSpeed = initPlayerSpeed;
        ai.moveSpeed = initEnemySpeed;

        dificultyIncrementSpeed += 2f;
        player.moveSpeed += dificultyIncrementSpeed;
        ai.moveSpeed += dificultyIncrementSpeed;
    }

    public void Restart()
    {
        playing = true;

        // Destroy the current player and AI game objects
        Destroy(player.gameObject);
        Destroy(ai.gameObject);

        // Instantiate new Player and AI in this object's position
        GameObject newPlayer = Instantiate(playerPrefab, initPlayer, Quaternion.identity, transform);
        GameObject newAI = Instantiate(enemyPrefab, initEnemy, Quaternion.identity, transform);

        // Reference the new player and AI to the variables
        player = newPlayer.GetComponent<PlayerControllerTron>();
        player.gameManager = this;
        ai = newAI.GetComponent<AIControllerTron>();
        ai.gameManager = this;
        ai.player = player.transform;
        player.ai = ai;

        // Reset their speeds to initial values
        player.moveSpeed = initPlayerSpeed;
        ai.moveSpeed = initEnemySpeed;

        dificultyIncrementSpeed = 2;
    }

    public void LeveWin()
    {
        playing = false;
        status.text = "Venceu esse level R para o proximo";
    }

    public void GameOver()
    {
        playing = false;
        status.text = "Fim de jogo! Pontuação final: " + score;
    }
}
