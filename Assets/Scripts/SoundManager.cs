using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] private AudioSource bgMusicSource;
    [SerializeField] private AudioSource sfxAudioSource;
    [SerializeField] private AudioClip clickSfx;
    [SerializeField] private AudioClip collectSfx;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        bool isSoundOn = PlayerPrefs.GetInt("Sound", 1) == 1;
        SetSoundState(isSoundOn);
    }
    public void PlaySfx(AudioClipType audioClipType)
    {
        AudioClip audioClip=null;
        switch (audioClipType)
        {
            case AudioClipType.CLICK:
                audioClip = clickSfx;
                break;
            case AudioClipType.COLLECT:
                audioClip = collectSfx;
                break;
        }
        sfxAudioSource.PlayOneShot(audioClip);
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
public enum AudioClipType
{
    CLICK,
    COLLECT
}
