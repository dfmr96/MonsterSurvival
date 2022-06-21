using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceBooster : MonoBehaviour
{
    [SerializeField] PowerInfo powerInfo;

    private void Start()
    {
        powerInfo = this.gameObject.GetComponent<PowerInfo>();
    }
    void Update()
    {
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
                powerInfo.powerDescription = "Increase experience gained by 6%";
                break;


            case 2:
                Debug.Log(powerInfo.name + "Subido a nivel 2");
                powerInfo.powerDescription = "Increase experience gained by 9%";
                powerInfo.multiplier = 1.06f;
                break;

            case 3:
                Debug.Log(powerInfo.name + "Subido a nivel 3");
                powerInfo.powerDescription = "Increase experience gained by 15%";
                powerInfo.multiplier = 1.09f;
                break;

            case 4:
                Debug.Log(powerInfo.name + "Subido a nivel 4");
                powerInfo.powerDescription = "Increase experience gained by 25%";
                powerInfo.multiplier = 1.15f;
                break;

            case 5:
                Debug.Log(powerInfo.name + "Subido a nivel 5");
                powerInfo.powerDescription = "Increase experience gained by 35%";
                powerInfo.multiplier = 1.25f;
                break;

            case 6:
                Debug.Log(powerInfo.name + "Subido a nivel 6");
                powerInfo.powerDescription = "Increase experience gained by 50%";
                powerInfo.multiplier = 1.35f;
                break;

            case 7:
                Debug.Log(powerInfo.name + "Subido a nivel 7");
                powerInfo.multiplier = 1.5f;
                break;


        }
    }
}
