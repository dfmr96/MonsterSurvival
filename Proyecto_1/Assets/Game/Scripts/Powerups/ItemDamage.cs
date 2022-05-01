using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDamage : MonoBehaviour
{
    public Transform player;
    [SerializeField] Collider2D[] enemiesInsideArea;
    [SerializeField] LayerMask mask;
    [SerializeField] float coolDownCounter;
    [SerializeField] PowerInfo powerInfo;

    public void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        transform.position = player.position;
        coolDownCounter = 0;
    }
    private void Update()
    {
        transform.position = player.position;
        coolDownCounter += Time.deltaTime;

        if (coolDownCounter >= powerInfo.coolDown)
        {
            DamageEnemies();
            coolDownCounter = 0;
        }
    }

    public void DamageEnemies()
    {
        enemiesInsideArea = Physics2D.OverlapCircleAll(transform.position, powerInfo.radius, mask);

        foreach (Collider2D enemyCol in enemiesInsideArea)
        {
            enemyCol.GetComponent<EnemyStats>().TakeDamage(powerInfo.damage);

        }
    }

   /* private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radiusOfDamage);
    }
   */
}
