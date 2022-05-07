using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayGameButton : MonoBehaviour
{
    [SerializeField] Button button;

    public void PlayGame()
    {
        if (EnergyManager.sharedInstance.totalEnergy > 0)
        {
            SceneManager.LoadScene("Game");
            EnergyManager.sharedInstance.UseEnergy();

        }
    }

    private void Update()
    {
        if (EnergyManager.sharedInstance.totalEnergy == 0)
        {
            GetComponent<Button>().interactable = false;
        }
    }


}
