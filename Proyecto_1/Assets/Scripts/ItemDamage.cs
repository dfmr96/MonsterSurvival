using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDamage : MonoBehaviour
{
    [SerializeField] int damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            Debug.Log("Chocamos con Enemy");
            collision.GetComponent<EnemyController>().TakeDamage(damage);
        }
    }
}
