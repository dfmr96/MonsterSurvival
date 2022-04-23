using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance;
    public int enemiesKilled;
    public int timerSeconds, timerMinutes;

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
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

    private void Start()
    {
        StartCoroutine(timerRoutine()); 
    }
}