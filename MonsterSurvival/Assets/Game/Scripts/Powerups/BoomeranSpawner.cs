using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomeranSpawner : MonoBehaviour
{
    public PowerInfo powerInfo;
    Transform player;
    [SerializeField] GameObject boomeranPrefab;
    [SerializeField] float coolDownCounter;

    private void Start()
    {
        //Var init
        player = FindObjectOfType<PlayerController>().transform;
        coolDownCounter = 0f;
    }

    private void Update()
    {
        //Cooldown counter
        coolDownCounter += Time.deltaTime;

        //Countdown reset and create projectile
        if(coolDownCounter>=powerInfo.coolDown)
        {
            Instantiate(boomeranPrefab, player.position, Quaternion.identity);
            coolDownCounter = 0f;
        }

        //Check level up
        if (powerInfo.leveledUp)
        {
            UpdateStats();
            powerInfo.leveledUp = false;
        }
    }

    public void UpdateStats()
    {
        switch (powerInfo.currentLevel)
        {
            case 1:
                Debug.Log(powerInfo.name + "Nivel 1");
                powerInfo.powerDescription = "Increase damage by 2";  
                break;


            case 2:
                Debug.Log(powerInfo.name + "Subido a nivel 2");
                powerInfo.powerDescription = "Increase ricochets by 1";
                powerInfo.damage += 2;
                break;

            case 3:
                Debug.Log(powerInfo.name + "Subido a nivel 3");
                powerInfo.powerDescription = "Increase speed by 3";
                powerInfo.health += 3;
                break;

            case 4:
                Debug.Log(powerInfo.name + "Subido a nivel 4");
                powerInfo.powerDescription = "Decrease cooldown by 25%";
                powerInfo.speed++;
                break;

            case 5:
                Debug.Log(powerInfo.name + "Subido a nivel 5");
                powerInfo.powerDescription = "Increase damage by 2";
                powerInfo.coolDown *= 0.75f;
                break;

            case 6:
                Debug.Log(powerInfo.name + "Subido a nivel 6");
                powerInfo.powerDescription = "Increase damage by 2";
                powerInfo.damage += 2;
                break;
            case 7:
                Debug.Log(powerInfo.name + "Subido a nivel 6");
                powerInfo.powerDescription = "Increase damage by 3";
                powerInfo.damage += 3;
                break;



        }
    }
}
