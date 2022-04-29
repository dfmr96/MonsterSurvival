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


    public float health;
    public float defense;
    public float damage;
    public float angularSpeed;
    public float speed;
    public float coolDown;
    public float radius;

    public void LevelUp()
    {
        currentLevel++;
        //UpdatePowerInfo();
    }

    //public void UpdatePowerInfo()
    //{
    //    switch (currentLevel)
    //    {
    //        case 1: 
    //            powerName = "";
    //            break;


    //    }
    //}
}
