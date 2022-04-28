

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int currentLevel;
    public int currentExp;
    public int[] expToLevelUp;
    public float health;
    public float maxHealth = 10;

    private void Start()
    {
        health = maxHealth;
    }
    // Update is called once per frame
    void Update()
    {
        if (currentLevel >= expToLevelUp.Length)
        {
            return;
        }

        if (currentExp >= expToLevelUp[currentLevel])
        {
            currentLevel++;
            if(currentLevel != 1)
            {
            GameManager.sharedInstance.levelUpScreenManager.ShowLevelUpScreen();
            }
        }

        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void AddExperience(int exp)
    {
        currentExp += exp;
    }

    public void TakeDamage(float damage)
    {
        damage -= FindObjectOfType<DefenseUp>().defenseBonus[1];
        health -= damage;
        Debug.Log("Recibio" + damage);
    }
}
