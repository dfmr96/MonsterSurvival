using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenController : MonoBehaviour
{
    Transform player;
    Vector3 vectorPosition;
    ShurikensSpawner spawner;
    public float shurikenHealth, shurikenDamage;

    void Start()
    {
        //Var init
        player = FindObjectOfType<PlayerController>().transform;
        spawner = FindObjectOfType<ShurikensSpawner>();

        //Stats
        shurikenHealth = spawner.powerInfo.health;
        shurikenDamage = spawner.powerInfo.damage;
    }

    void Update()
    {
        spawner = FindObjectOfType<ShurikensSpawner>();

        if (shurikenHealth <= 0)
        {
            gameObject.SetActive(false);
            FindObjectOfType<ShurikensSpawner>().shurikenAmount--;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyStats>().TakeDamage(spawner.powerInfo.damage);
            shurikenHealth--;
        }else if (collision.CompareTag("Breakable"))
        {
            collision.GetComponent<PotBreakable>().TakeDamage(spawner.powerInfo.damage);
            shurikenHealth--;

        }
    }
}
