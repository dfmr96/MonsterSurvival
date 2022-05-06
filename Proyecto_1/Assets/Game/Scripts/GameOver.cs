using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject GameOverScreen;
    [SerializeField] GameObject reviveButtom;
    bool canRevive = true;
    PlayerStats player;

    private void Start()
    {
        player = FindObjectOfType<PlayerStats>();
    }
    private void Update()
    {
        if (GameManager.sharedInstance.playerLifes <= 0)
        {
            canRevive = false;
        }
        if (!canRevive)
        {
            reviveButtom.SetActive(false);
        }
    }
    public void TryAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }

    public void ShowGameOverScreen()
    {
        GameOverScreen.SetActive(true);
        Time.timeScale = 0;


    }
    public void HideGameOverScreen()
    {
        GameOverScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void Revive()
    {
        GameManager.sharedInstance.playerLifes--;
        HideGameOverScreen();
        player.health = player.maxHealth;
    }


}
