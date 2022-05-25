using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingButton : MonoBehaviour
{
    [SerializeField] GameObject settingScreen, pauseScreen;
    [SerializeField] Button settingButton;
    public void GoToSettingsScreen()
    {
        pauseScreen.SetActive(false);
        settingScreen.SetActive(true);
    }
}
