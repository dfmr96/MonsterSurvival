using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDamage : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] Collider2D[] objectsInsideArea;
    [SerializeField] float radiusOfDamage = 0.5f;
    [SerializeField] LayerMask mask;
    [SerializeField] float weaponCooldown = 2f;
    PlayerStats playerStats;
    public void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        StartCoroutine(DamageEnemy());
    }
    private void Update()
    {
        objectsInsideArea = Physics2D.OverlapCircleAll(transform.position, radiusOfDamage, mask);

    }

    IEnumerator DamageEnemy()
    {
        while (true)
        {
            foreach (Collider2D collider2D in objectsInsideArea)
            {
                collider2D.GetComponent<EnemyStats>().TakeDamage(damage);
            }
            yield return new WaitForSeconds(weaponCooldown);
        }
    }

   /* private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radiusOfDamage);
    }
   */
}
