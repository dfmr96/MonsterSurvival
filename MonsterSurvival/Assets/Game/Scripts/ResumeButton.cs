using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResumeButton : MonoBehaviour
{
    [SerializeField] Button resumeButton;
    [SerializeField] GameObject pauseScreen, choosePowerScreen;
    public void ResumeGame()
    {
        pauseScreen.SetActive(false);
        if (choosePowerScreen.activeInHierarchy == false)
        {
            Time.timeScale = 1;
        }
    }
}
