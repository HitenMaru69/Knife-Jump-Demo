using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;
    public TextMeshProUGUI scoreTxt;
    public int score = 0;
    public bool isMoveCamera;
    public bool isPlayerDie;

    [SerializeField] Canvas gameOverCanvas;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if(isPlayerDie)
        {
            GameOver gameOver = gameOverCanvas.GetComponent<GameOver>();

            gameOver.SetSCore();

            gameOverCanvas.enabled = true;

            isPlayerDie = false;
        }
    }

    public void ScoreUpdate()
    {
        score += 1;
        scoreTxt.text = "Score: " + score;
        PlayerPrefs.SetInt("Score", score);
 
    }


}
