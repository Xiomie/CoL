using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    float currentScore = 0;
    public Text ScoreText;

    private void Start()
    {
        ScoreText.text = "Score: " + currentScore;
        
    }

    public void AddScore()
    {
        currentScore ++;
        ScoreText.text = "Score: " + currentScore;

        if (currentScore >= 8)
        {
            SceneManager.LoadScene("WinScene");
        }
    }
}
