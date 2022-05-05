using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager sharedInstance;
    public AudioSource confirmSound, gemPick;

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

    public void ChoosePowerSound()
    {
        confirmSound.Play();
    }

    public void GemPicked()
    {
        gemPick.Play();
    }
}
