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
                powerInfo.powerDescription = "Increase experience gained by 10%";
                powerInfo.multiplier = 1.1f;

                break;


            case 2:
                Debug.Log(powerInfo.name + "Subido a nivel 2");
                powerInfo.powerDescription = "Increase experience gained by 20%";
                powerInfo.multiplier = 1.2f;
                break;

            case 3:
                Debug.Log(powerInfo.name + "Subido a nivel 3");
                powerInfo.powerDescription = "Increase experience gained by 35%";
                powerInfo.multiplier = 1.4f;
                break;

            case 4:
                Debug.Log(powerInfo.name + "Subido a nivel 4");
                powerInfo.powerDescription = "Increase experience gained by 50%";
                powerInfo.multiplier = 1.75f;
                break;

            case 5:
                Debug.Log(powerInfo.name + "Subido a nivel 5");
                powerInfo.multiplier = 2.25f;
                break;


        }
    }
}
