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
    public bool canRevive = true;
    [SerializeField] GameObject reviveButtom;


    void Update()
    {
        var delta = playerStatsManager.expToLevelUp[playerStatsManager.currentLevel - 1];
        var deltaExp = playerStatsManager.currentExp - delta;
        var deltaMaxExp = playerStatsManager.expToLevelUp[playerStatsManager.currentLevel] - delta;

        //Barras
        playerExpBar.maxValue = deltaMaxExp;
        playerExpBar.value = deltaExp;

        //Texto
        StringBuilder sb = new StringBuilder("");
        
        playerExpText.text = deltaExp + "/" + deltaMaxExp;
        currentLevel.text = "Level:" + playerStatsManager.currentLevel;
        enemiesKilled.text = GameManager.sharedInstance.enemiesKilled.ToString();
        timer.text = GameManager.sharedInstance.timerMinutes.ToString("00") + ":"+GameManager.sharedInstance.timerSeconds.ToString("00");



    }


}
