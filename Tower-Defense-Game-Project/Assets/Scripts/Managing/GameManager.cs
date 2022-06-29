using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;

    public string nextLevel = "Level02";
    public int levelToUnlock = 2;

    public SceneFader sceneFader;

    public static bool GameIsOver = false;


    private void Start()
    {
        GameIsOver = false;
        gameOverUI.SetActive(false);
    }

    void Update()
    {
        if (GameIsOver) return;

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        Debug.Log("Win");
        PlayerPrefs.SetInt("LevelReacher", levelToUnlock);
        sceneFader.FadeTo(nextLevel);
    }
}
