using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningRing : MonoBehaviour
{
    public Transform player;
    [SerializeField] Collider2D[] enemiesInsideArea;
    public GameObject closestEnemy;
    [SerializeField] LayerMask mask;
    [SerializeField] float coolDownCounter;
    [SerializeField] PowerInfo powerInfo;

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
            closestEnemy.GetComponent<EnemyStats>().TakeDamage(powerInfo.damage);
            coolDownCounter = 0f;
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
            if(currentDistance<closestDistance)
            {
                closestDistance = currentDistance;
                closestEnemy = enemyCol.gameObject;
            }
        }
        return closestEnemy;
    }
}
