using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class RestartButton : MonoBehaviour
{
    [SerializeField] Button restartButton;
    [SerializeField] GameObject pauseScreen;
    public void RestartGame()
    {
    if (EnergyManager.sharedInstance.totalEnergy > 0)
        {
            EnergyManager.sharedInstance.totalEnergy--;
            Time.timeScale = 1;
            SceneManager.LoadScene("Game");
        }
    }
}
