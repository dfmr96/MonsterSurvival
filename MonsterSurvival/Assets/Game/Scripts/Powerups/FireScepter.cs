using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScepter : MonoBehaviour
{
    Transform player;
    [SerializeField] Collider2D[] enemiesInsideArea;
    public GameObject closestEnemy;
    [SerializeField] LayerMask mask;
    [SerializeField] float coolDownCounter;
    [SerializeField] PowerInfo powerInfo;
    public Vector3 enemyDirection;
    [SerializeField] GameObject fireBallPrefab;

    private void Start()
    {
        closestEnemy = null;
        player = FindObjectOfType<PlayerController>().transform;
        transform.position = player.position;
        coolDownCounter = 0;

    }

    private void Update()
    {
        transform.position = player.transform.position;
        coolDownCounter += Time.deltaTime;

        if (coolDownCounter >= powerInfo.coolDown)
        {
            getClosestEnemy();
            if (closestEnemy != null)
            {
                if (closestEnemy.CompareTag("Enemy"))
                {
                    enemyDirection = closestEnemy.transform.position - transform.position;
                    Instantiate(fireBallPrefab, player.position, Quaternion.identity);
                }
                else if (closestEnemy.CompareTag("Breakable"))
                {
                    closestEnemy.GetComponent<PotBreakable>().TakeDamage(powerInfo.damage);
                    Instantiate(fireBallPrefab, player.position, Quaternion.identity);
                }
            }
            coolDownCounter = 0f;
        }

        if (powerInfo.leveledUp)
        {
            UpdateStats();
            powerInfo.leveledUp = false;
        }
    }

    public GameObject getClosestEnemy()
    {
        enemiesInsideArea = Physics2D.OverlapCircleAll(transform.position, powerInfo.radius, mask);
        float closestDistance = Mathf.Infinity;
        foreach (Collider2D enemyCol in enemiesInsideArea)
        {
            float currentDistance;
            currentDistance = Vector3.Distance(transform.position, enemyCol.transform.position);
            if (currentDistance < closestDistance)
            {
                closestDistance = currentDistance;
                closestEnemy = enemyCol.gameObject;
            }
        }
        return closestEnemy;
    }

    public void UpdateStats()
    {
        switch (powerInfo.currentLevel)
        {
            case 1:
                Debug.Log(powerInfo.name + "Nivel 1");
                powerInfo.powerDescription = "Increase radius by 50%";

                break;


            case 2:
                Debug.Log(powerInfo.name + "Subido a nivel 2");
                powerInfo.powerDescription = "Decrease cooldown by 25%";
                powerInfo.radius *= 1.5f;
                break;

            case 3:
                Debug.Log(powerInfo.name + "Subido a nivel 3");
                powerInfo.powerDescription = "Increase damage by 5";
                powerInfo.coolDown *= 0.75f;
                break;

            case 4:
                Debug.Log(powerInfo.name + "Subido a nivel 4");
                powerInfo.powerDescription = "Decrease cooldown by 50%";
                powerInfo.damage += 5;
                break;

            case 5:
                powerInfo.powerDescription = "Increase damage by 5";
                powerInfo.coolDown *= 0.5f;
                break;


        }
    }
}
