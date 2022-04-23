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
    public TMP_Text power1Name, power2Name;
    int randomPower2;

    public void ShowLevelUpScreen()
    {
        levelUpScreen.SetActive(true);
        Time.timeScale = 0;
        randomPower2 = Random.Range(0, powerUpsPoolManager.PowerUps.Length);
    }
    public void HideLevelupScreen()
    {
        levelUpScreen.SetActive(false);
        Time.timeScale = 1;
    }

    private void Update()
    {
        power1Name.text = powerUpsPoolManager.PowerUps[3].GetComponent<HealthUp>().skillName.ToString();
        power2Name.text = randomPower2.ToString();
    }


}
