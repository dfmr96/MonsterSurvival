using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowersManager : MonoBehaviour
{
    public PowerUpsPool powerUpsPoolManager;
    public GameObject powerChosenGO;
    public string powerChosenName;

    //public void LevelUpGarlic(int )
    //{
    //    if (GameObject.Find("Garlic") == null)
    //    {
    //        Instantiate(powerUpsPoolManager.powerUps[randomPower1]);

    //    }
    //}

    public void CheckRandomPower(int randomPower)
    {
        powerChosenGO = powerUpsPoolManager.powerUps[randomPower];
        powerChosenName = powerChosenGO.GetComponent<PowerInfo>().powerName;
        Debug.Log(powerChosenName);
        LevelUpPower(powerChosenName);
    }

    public void LevelUpPower(string powerChosen)
    {
        if (GameObject.FindGameObjectWithTag(powerChosen) == null)
        {
            Instantiate(powerChosenGO);
            Debug.Log(powerChosenName + "creado");
        } else
        {
            GameObject.FindGameObjectWithTag(powerChosen).GetComponent<PowerInfo>().level++;
        }
    }
}
