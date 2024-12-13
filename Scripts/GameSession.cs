using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Don't forget to include this for SceneManager
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3, score = 10;
    [SerializeField] Text scoreText, livesText;

    private void Start()
    {
        livesText.text = playerLives.ToString();
        scoreText.text = score.ToString();
    }

    public void AddToScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
    }

    private void ReduceLife()
    {
        playerLives--;
        livesText.text = playerLives.ToString();
    }

    public void AddToLives()
    {
        playerLives++;
        livesText.text = playerLives.ToString();
    }

    private void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length; // Change FindObjectOfType to FindObjectsOfType

        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            ReduceLife();
        }
        else
        {
            ResetGame();
        }
    }

    private void ResetGame()
    {
        SceneManager.LoadScene(0); // Make sure to load your starting scene by index 0
        Destroy(gameObject);
    }
}
