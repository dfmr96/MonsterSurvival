using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject GameOverScreen;
    public void TryAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }

    public void ShowGameOverScreen()
    {
        GameOverScreen.SetActive(true);
        Time.timeScale = 0;


    }
    public void HideGameOverScreen()
    {
        GameOverScreen.SetActive(false);
        Time.timeScale = 1;
    }
}
