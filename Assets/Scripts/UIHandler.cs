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
    private void OnEnable()
    {
        restartButton.onClick.AddListener(GameRestart);
        EventHandler.OnGameOver += GameOver;
        EventHandler.OnScoreChange += UpdateScoreUI;
    }
    private void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
    private void UpdateScoreUI(int score)
    {
        scoreText.text = score.ToString();
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
