using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthDisplay : MonoBehaviour
{
    public Slider healthBar;
    [SerializeField] PlayerStats playerStatsManager;

    // Update is called once per frame
    void Update()
    {
        healthBar.maxValue = playerStatsManager.maxHealth;
        healthBar.value = playerStatsManager.health;

    }
}
