using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerInfo : MonoBehaviour
{
    public string powerName, powerDescription;
    public Sprite powerIcon;
    public int currentLevel = 1;
    public int maxLevel;
    public bool leveledUp = false;


    public float health;
    public float defense;
    public float damage;
    public float angularSpeed;
    public float speed;
    public float coolDown;
    public float radius;
    public float multiplier;
    public int projectiles;

    private void Start()
    {
        leveledUp = true;
    }
    public void LevelUp()
    {
        currentLevel++;
        leveledUp = true;
    }
}
