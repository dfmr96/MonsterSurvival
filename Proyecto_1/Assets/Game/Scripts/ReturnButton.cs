using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnButton : MonoBehaviour
{
    [SerializeField] GameObject settingScreen, pauseScreen;

    public void ReturnToPauseScreen()
    {
        settingScreen.SetActive(false);
        pauseScreen.SetActive(true);
    }
}
