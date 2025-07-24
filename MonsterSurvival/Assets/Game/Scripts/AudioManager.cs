using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] SettingMenu audioSetting;
    public static AudioManager sharedInstance;
    public AudioSource confirmSound, gemPick;
    public const string MUSIC_KEY = "musicVolume", SFX_KEY = "sfxVolume";

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }

    public void ChoosePowerSound()
    {
        confirmSound.Play();
    }

    public void GemPicked()
    {
        gemPick.Play();
    }
    void LoadVolume()
    {
        float musicVolume = PlayerPrefs.GetFloat(MUSIC_KEY);
        float sfxVolume = PlayerPrefs.GetFloat(SFX_KEY);

        audioMixer.SetFloat(SettingMenu.MIXER_MUSIC, musicVolume);
        audioMixer.SetFloat(SettingMenu.MIXER_SFX, sfxVolume);
    }

}
