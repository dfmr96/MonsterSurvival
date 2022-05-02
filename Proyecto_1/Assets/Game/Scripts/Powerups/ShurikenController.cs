using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenController : MonoBehaviour
{
    Transform player;
    Vector3 vectorPosition;
    ShurikensSpawner spawner;
    [SerializeField] float shurikenHealth, shurikenDamage;

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
            collision.GetComponent<EnemyStats>().TakeDamage(shurikenDamage);
            shurikenHealth--;
        }
    }
}
