using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Button restartButton;
    private void OnEnable()
    {
        restartButton.onClick.AddListener(GameRestart);
        EventHandler.OnGameOver += GameOver;
    }
    private void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
    private void GameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnDisable()
    {
        EventHandler.OnGameOver -= GameOver;
    }
}
