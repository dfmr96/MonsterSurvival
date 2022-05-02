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
                playerController.speed *= 1.1f;
                break;


            case 2:
                Debug.Log(powerInfo.name + "Subido a nivel 2");
                powerInfo.powerDescription = "Increase speed by 15%";
                playerController.speed *= 1.1f;
                break;

            case 3:
                Debug.Log(powerInfo.name + "Subido a nivel 3");
                powerInfo.powerDescription = "Increase speed by 20%";
                playerController.speed *= 1.15f;
                break;

            case 4:
                Debug.Log(powerInfo.name + "Subido a nivel 4");
                powerInfo.powerDescription = "Increase speed by 25%";
                playerController.speed *= 1.20f;
                break;

            case 5:
                Debug.Log(powerInfo.name + "Increase speed by 30%");
                playerController.speed *= 1.25f;
                break;


        }
    }
}

