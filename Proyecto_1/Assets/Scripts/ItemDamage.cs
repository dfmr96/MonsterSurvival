using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDamage : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] Collider2D[] objectsInsideArea;
    [SerializeField] float radiusOfDamage;
    [SerializeField] LayerMask mask;
    [SerializeField] float weaponCooldown = 2f;

    private void Awake()
    {
        radiusOfDamage = GetComponent<CircleCollider2D>().radius;
    }
    public void Start()
    {
        StartCoroutine(DamageEnemy());
    }

    IEnumerator DamageEnemy()
    {
        while (true)
        {
            objectsInsideArea = Physics2D.OverlapCircleAll(transform.position, radiusOfDamage, mask);
            foreach (Collider2D collider2D in objectsInsideArea)
            {
                collider2D.GetComponent<EnemyController>().TakeDamage(damage);
            }

            yield return new WaitForSeconds(weaponCooldown);
        }
    }
}
