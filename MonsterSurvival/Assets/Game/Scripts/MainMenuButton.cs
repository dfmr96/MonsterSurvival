using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenuButton : MonoBehaviour
{
    
    public void MainMenuScene() 
    {
        SceneManager.LoadScene("MainScreen");
        
        EnergyManager.sharedInstance.UpdateEnergy();
        EnergyManager.sharedInstance.UpdateTimer();
    }
}
