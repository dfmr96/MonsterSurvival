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
    }
}
