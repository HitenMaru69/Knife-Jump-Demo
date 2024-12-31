using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI highScore;
    [SerializeField] Gamemanager gamemanager;

    public void Restart_BU()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void SetSCore()
    {
        score.text = "Score: " + PlayerPrefs.GetInt("Score", 0);
        CheckHighScore();
    }

    void CheckHighScore()
    {
        if(PlayerPrefs.GetInt("Score") >= PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("Score"));
            highScore.text = "High Score : " + PlayerPrefs.GetInt("HighScore");
        }
        else
        {
            highScore.text = "High Score : " + PlayerPrefs.GetInt("HighScore");
        }
    }
}
