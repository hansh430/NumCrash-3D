using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Button restartButton;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private Toggle soundToggle;

    private int currentScore = 0;
    private int currentHighScore = 0;
    private void OnEnable()
    {
        restartButton.onClick.AddListener(GameRestart);
        EventHandler.OnGameOver += GameOver;
        EventHandler.OnScoreChange += UpdateScoreUI;
    }
    private void Start()
    {
        currentHighScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = currentHighScore.ToString();
        bool isSoundOn = PlayerPrefs.GetInt("Sound", 1) == 1;
        soundToggle.isOn = isSoundOn;
    }
    private void GameOver()
    {
        gameOverPanel.SetActive(true);
        UpdateHighScore();
    }
    private void UpdateScoreUI(int score)
    {
        currentScore = score;
        scoreText.text = score.ToString();
        if(currentScore>currentHighScore)
        {
            currentHighScore=currentScore;
            PlayerPrefs.SetInt("HighScore", currentHighScore);
            PlayerPrefs.Save();
        }
    }
    private void UpdateHighScore()
    {
        currentHighScore = PlayerPrefs.GetInt("HighScore", 0);
        if (currentScore > currentHighScore)
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
            PlayerPrefs.Save();
            highScoreText.text = currentScore.ToString();
        }
        else
        {
            highScoreText.text = currentHighScore.ToString();
        }
    }
    private void GameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnDisable()
    {
        EventHandler.OnGameOver -= GameOver;
        EventHandler.OnScoreChange -= UpdateScoreUI;
    }
}
