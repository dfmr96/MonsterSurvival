using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TutorialScreen : MonoBehaviour
{
    [SerializeField] GameObject tutorialScreen;

    public void QuitTutorialScreen()
    {
        tutorialScreen.SetActive(false);
        PlayerPrefs.SetString("tutorial_active", "false");
        Time.timeScale = 1;
    }
    public void ShowTutorialScreen()
    {
        tutorialScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
