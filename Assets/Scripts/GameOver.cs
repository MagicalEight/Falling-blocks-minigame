using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Text secondsSurvivedUI;
    private bool gameOver;

    void Start()
    {
        FindObjectOfType<PlayerController>().OnplayerDeath += OnGameOver; // 开始的时候把 OnGameOver method 绑到 OnPlayerDeath event
    }
    
    void Update()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                SceneManager.LoadScene(0);
        }
    }

    void OnGameOver()
    {
        gameOverScreen.SetActive(true);
        secondsSurvivedUI.text = Math.Round(Time.timeSinceLevelLoad, 2).ToString();
        gameOver = true;
    }
}
