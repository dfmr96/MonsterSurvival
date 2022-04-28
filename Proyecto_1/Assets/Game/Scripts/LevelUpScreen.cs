using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelUpScreen : MonoBehaviour
{
    public GameObject levelUpScreen;
    public PlayerStats playerStats;
    public PowerUpsPool powerUpsPoolManager;
    public TMP_Text power1Name, power1Description, power2Name, power2Description, power3Name, power3Description;
    public GameObject power1Icon, power2Icon, power3Icon;
    int randomPower1, randomPower2, randomPower3;

    public void ShowLevelUpScreen()
    {
        levelUpScreen.SetActive(true);
        Time.timeScale = 0;
        ShowPower1();
        ShowPower2();
        ShowPower3();


    }
    public void HideLevelupScreen()
    {
        levelUpScreen.SetActive(false);
        Time.timeScale = 1;
    }


    public void ShowPower1()
    {
        randomPower1 = Random.Range(0, powerUpsPoolManager.powerUps.Count);
        power1Name.text = powerUpsPoolManager.powerUps[randomPower1].GetComponent<PowerInfo>().powerName.ToString();
        power1Description.text = powerUpsPoolManager.powerUps[randomPower1].GetComponent<PowerInfo>().powerDescription.ToString();
        power1Icon.GetComponent<Image>().sprite = powerUpsPoolManager.powerUps[randomPower1].GetComponent<PowerInfo>().powerIcon;
        powerUpsPoolManager.powerUps.RemoveAt(randomPower1);
    }

    public void ShowPower2()
    {
        randomPower2 = Random.Range(0, powerUpsPoolManager.powerUps.Count);
        power2Name.text = powerUpsPoolManager.powerUps[randomPower2].GetComponent<PowerInfo>().powerName.ToString();
        power2Description.text = powerUpsPoolManager.powerUps[randomPower2].GetComponent<PowerInfo>().powerDescription.ToString();
        power2Icon.GetComponent<Image>().sprite = powerUpsPoolManager.powerUps[randomPower2].GetComponent<PowerInfo>().powerIcon;
        powerUpsPoolManager.powerUps.RemoveAt(randomPower2);
    }

    public void ShowPower3()
    {
        randomPower3 = Random.Range(0, powerUpsPoolManager.powerUps.Count);
        power3Name.text = powerUpsPoolManager.powerUps[randomPower3].GetComponent<PowerInfo>().powerName.ToString();
        power3Description.text = powerUpsPoolManager.powerUps[randomPower3].GetComponent<PowerInfo>().powerDescription.ToString();
        power3Icon.GetComponent<Image>().sprite = powerUpsPoolManager.powerUps[randomPower3].GetComponent<PowerInfo>().powerIcon;
        powerUpsPoolManager.powerUps.RemoveAt(randomPower3);

    }
}
