using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomeranSpawner : MonoBehaviour
{
    [SerializeField] PowerInfo powerInfo;
    Transform player;
    [SerializeField] GameObject boomeranPrefab;
    [SerializeField] float coolDownCounter;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        coolDownCounter = 0f;
    }

    private void Update()
    {
        coolDownCounter += Time.deltaTime;
        if(coolDownCounter>=powerInfo.coolDown)
        {
            Instantiate(boomeranPrefab, player.position, Quaternion.identity);
            coolDownCounter = 0f;
        }
    }
}
