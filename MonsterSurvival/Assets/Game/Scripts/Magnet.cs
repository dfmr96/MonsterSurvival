using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    [SerializeField] CircleCollider2D gemTakerArea;
    [SerializeField] PowerInfo powerInfo;

    private void Start()
    {
        powerInfo = GetComponent<PowerInfo>();
        gemTakerArea = FindObjectOfType<PlayerStats>().GetComponentInChildren<CircleCollider2D>();
    }
    private void Update()
    {
        if (powerInfo.leveledUp)
        {
            UpdateStats();
            powerInfo.leveledUp = false;
        }
    }

    public void UpdateStats()
    {
       // float radius = gemTakerArea.radius;
        float multiplier = powerInfo.multiplier;
      //  multiplier = radius;
        switch (powerInfo.currentLevel)
        {
            case 1:
                Debug.Log(powerInfo.name + "Nivel 1");
                powerInfo.powerDescription = "Increase area by 20%";
                powerInfo.multiplier = 1.5f;
                gemTakerArea.radius = 1.5f;
                break;


            case 2:
                Debug.Log(powerInfo.name + "Subido a nivel 2");
                powerInfo.powerDescription = "Increase area by 25%";
                powerInfo.multiplier *= 1.2f;
                gemTakerArea.radius *= 1.2f;

                break;

            case 3:
                Debug.Log(powerInfo.name + "Subido a nivel 3");
                powerInfo.powerDescription = "Increase area by 40%";
                powerInfo.multiplier *= 1.25f;
                gemTakerArea.radius *= 1.25f;

                break;

            case 4:
                Debug.Log(powerInfo.name + "Subido a nivel 4");
                powerInfo.powerDescription = "Increase area by 65%";
                powerInfo.multiplier *= 1.4f;
                gemTakerArea.radius *= 1.4f;

                break;

            case 5:
                Debug.Log(powerInfo.name + "Subido a nivel 5");
                powerInfo.multiplier *= 1.65f;
                gemTakerArea.radius *= 1.65f;

                break;


        }
    }
}
