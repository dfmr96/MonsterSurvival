using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : MonoBehaviour
{
    [SerializeField] PowerInfo powerInfo;
    [SerializeField] PlayerStats playerStats;
    public float playerMaxHealth;

    private void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
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
                powerInfo.powerDescription = "Increase max health by 10%";
                playerStats.maxHealth *= 1.1f;
                break;


            case 2:
                Debug.Log(powerInfo.name + "Subido a nivel 2");
                powerInfo.powerDescription = "Increase max health by 15%";
                playerStats.maxHealth *= 1.1f;
                break;

            case 3:
                Debug.Log(powerInfo.name + "Subido a nivel 3");
                powerInfo.powerDescription = "Increase max health by 20%";
                playerStats.maxHealth *= 1.15f;
                break;

            case 4:
                Debug.Log(powerInfo.name + "Subido a nivel 4");
                powerInfo.powerDescription = "Increase max health by 25%";
                playerStats.maxHealth *= 1.20f;
                break;

            case 5:
                Debug.Log(powerInfo.name + "Increase max health by 30%");
                playerStats.maxHealth *= 1.25f;
                break;


        }
    }
}
