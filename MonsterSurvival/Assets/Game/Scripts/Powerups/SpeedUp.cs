using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    [SerializeField] PowerInfo powerInfo;
    [SerializeField] PlayerController playerController;


    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        //Check level up
        if (powerInfo.leveledUp)
        {
            UpdateStats();
            powerInfo.leveledUp = false;
        }
    }

    public void UpdateStats()
    {
        switch (powerInfo.currentLevel)
        {
            case 1:
                Debug.Log(powerInfo.name + "Nivel 1");
                powerInfo.powerDescription = "Increase speed by 10%";
                playerController.speed *= 1.05f;
                break;


            case 2:
                Debug.Log(powerInfo.name + "Subido a nivel 2");
                powerInfo.powerDescription = "Increase speed by 12%";
                playerController.speed *= 1.10f;
                break;

            case 3:
                Debug.Log(powerInfo.name + "Subido a nivel 3");
                powerInfo.powerDescription = "Increase speed by 15%";
                playerController.speed *= 1.12f;
                break;

            case 4:
                Debug.Log(powerInfo.name + "Subido a nivel 4");
                powerInfo.powerDescription = "Increase speed by 18%";
                playerController.speed *= 1.15f;
                break;

            case 5:
                powerInfo.powerDescription = "Increase speed by 25%";
                playerController.speed *= 1.18f;
                break;

            case 6:
                powerInfo.powerDescription = "Increase speed by 35%";
                playerController.speed *= 1.25f;
                break;

            case 7:
                playerController.speed *= 1.35f;
                break;


        }
    }
}

