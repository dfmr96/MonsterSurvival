using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int currentLevel;
    public int currentExp;
    public int[] expToLevelUp;
    public int health = 10;

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

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
