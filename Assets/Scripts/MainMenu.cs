using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;

    private void OnEnable()
    {
        startButton.onClick.AddListener(StartGame);
        exitButton.onClick.AddListener(ExitGame);
    }
    private void StartGame()
    {
        SoundManager.Instance.PlaySfx(AudioClipType.CLICK);
        SceneManager.LoadScene(1);
    }
    private void ExitGame()
    {
        SoundManager.Instance.PlaySfx(AudioClipType.CLICK);
        Application.Quit();
    }
}
