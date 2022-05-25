using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseUp : MonoBehaviour
{
    public float[] defenseBonus;
    [SerializeField] PowerInfo powerInfo;

    private void Update()
    {
        //powerInfo.defense = defenseBonus[powerInfo.currentLevel];
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
                powerInfo.powerDescription = "Increase defense bonus by 1";
                break;


            case 2:
                Debug.Log(powerInfo.name + "Subido a nivel 2");
                powerInfo.powerDescription = "Increase defense bonus by 1";
                powerInfo.defense++;
                break;

            case 3:
                Debug.Log(powerInfo.name + "Subido a nivel 3");
                powerInfo.powerDescription = "Increase defense bonus by 1";
                powerInfo.defense++;
                break;

            case 4:
                Debug.Log(powerInfo.name + "Subido a nivel 4");
                powerInfo.powerDescription = "Increase defense bonus by 1";
                powerInfo.defense++;
                break;

            case 5:
                Debug.Log(powerInfo.name + "Increase defense bonus by 1");
                powerInfo.defense++;
                break;


        }
    }
}
