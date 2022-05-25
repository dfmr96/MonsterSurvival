using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    [SerializeField] Slider sfxSlider, musicSlider;
    public const string MIXER_MUSIC = "musicVolume", MIXER_SFX = "sfxVolume";
    private void Awake()
    {
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetFXVolume);
    }

    private void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat(AudioManager.MUSIC_KEY);
        sfxSlider.value = PlayerPrefs.GetFloat(AudioManager.SFX_KEY);
    }
    private void OnDisable()
    {
        PlayerPrefs.SetFloat(AudioManager.MUSIC_KEY, musicSlider.value);
        PlayerPrefs.SetFloat(AudioManager.SFX_KEY, sfxSlider.value);

    }

    public void SetFXVolume (float volume)
    {
        audioMixer.SetFloat(MIXER_SFX, volume);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat(MIXER_MUSIC, volume);
    }
}
