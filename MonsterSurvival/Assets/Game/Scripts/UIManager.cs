using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] TutorialScreen tutorialScreen;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("tutorial_active"))
        {
            tutorialScreen.GetComponent<TutorialScreen>().ShowTutorialScreen();

        }

    }

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

        playerExpText.text = ((uint)deltaExp) + "/" + ((uint)deltaMaxExp);
        currentLevel.text = "Level:" + playerStatsManager.currentLevel;
        enemiesKilled.text = GameManager.sharedInstance.enemiesKilled.ToString();
        timer.text = GameManager.sharedInstance.timerMinutes.ToString("00") + ":" + GameManager.sharedInstance.timerSeconds.ToString("00");



    }


}
