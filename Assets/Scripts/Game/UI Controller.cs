using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;

    [SerializeField] RawImage[] hearts;

    public bool scoreActive = true;

    public float score = 0;
    private float highScore = 0f;

    private void Start()
    {
        highScore = PlayerPrefs.GetFloat("HighScore", 0);
        UpdateScore();
    }
    private void Update()
    {
        if (scoreActive)
        {
            score += Time.deltaTime;

            if (score > highScore)
            {
                highScore = score;
                PlayerPrefs.SetFloat("HigScore", highScore);
                PlayerPrefs.Save();
            }
            UpdateScore();
        }
    }
    private void UpdateScore()
    {
        scoreText.text = "Score: " + (score * 2).ToString("F0");
        highScoreText.text = "High Score: " + (highScore * 2).ToString("F0");
    }
    public void UpdateLife(int hp)
    {
        foreach (RawImage heart in hearts)
        {
            heart.enabled = false;
        }

        for (int i = 0; i < hp; i++)
        {
            if (i < hearts.Length)
            {
                hearts[i].enabled = true;
            }
        }
    }
}