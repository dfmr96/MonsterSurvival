using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;

public class UIManager : MonoBehaviour
{
    public Slider playerExpBar;
    public TMP_Text playerExpText;
    public TMP_Text currentLevel;
    public TMP_Text enemiesKilled;
    public TMP_Text timer;
    [SerializeField] PlayerStats playerStatsManager;


    void Update()
    {
        var deltaExp = playerStatsManager.currentExp - playerStatsManager.expToLevelUp[playerStatsManager.currentLevel - 1];
        var deltaMaxExp = playerStatsManager.expToLevelUp[playerStatsManager.currentLevel] - playerStatsManager.expToLevelUp[playerStatsManager.currentLevel - 1];
        //Por si subimos de nivel
        playerExpBar.maxValue = deltaMaxExp;
        playerExpBar.value = deltaExp;


        StringBuilder sb = new StringBuilder("");
        
        playerExpText.text = deltaExp + "/" + deltaMaxExp;
        currentLevel.text = "Level:" + playerStatsManager.currentLevel;
        enemiesKilled.text = GameManager.sharedInstance.enemiesKilled.ToString();

        if (GameManager.sharedInstance.timerSeconds < 10)
        {
            timer.text = "0"+GameManager.sharedInstance.timerMinutes.ToString() + ":0"+GameManager.sharedInstance.timerSeconds.ToString();
        } else
        {
            timer.text = "0"+GameManager.sharedInstance.timerMinutes.ToString() + ":" + GameManager.sharedInstance.timerSeconds.ToString();
        }

    }
}
