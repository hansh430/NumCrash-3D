using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] private Toggle soundToggle;
    [SerializeField] private AudioSource bgMusicSource;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        bool isSoundOn = PlayerPrefs.GetInt("Sound", 1) == 1;
        soundToggle.isOn = isSoundOn;
        SetSoundState(isSoundOn);

    }

    public void SetSoundState(bool isOn)
    {
        AudioListener.volume = isOn ? 1f : 0f;

        if (bgMusicSource != null)
        {
            bgMusicSource.mute = !isOn;
        }

        PlayerPrefs.SetInt("Sound", isOn ? 1 : 0);
        PlayerPrefs.Save();

    }
}
