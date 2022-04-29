using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance;
    public int enemiesKilled;
    public int timerSeconds, timerMinutes;
    public LevelUpScreen levelUpScreenManager;
    public GameOver gameOverScreenManager;

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }
    private void Start()
    {
        Time.timeScale = 1;
        StartCoroutine(timerRoutine());
    }

    IEnumerator timerRoutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            timerSeconds++;
        }
    }

    private void Update()
    {
        if(timerSeconds == 60)
        {
            timerMinutes++;
            timerSeconds = 0;
        }
    }

    public void CallGameOverScreen()
    {
        gameOverScreenManager.ShowGameOverScreen();
    }
    
}