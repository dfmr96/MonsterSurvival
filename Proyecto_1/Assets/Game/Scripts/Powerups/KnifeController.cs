using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
public class KnifeController : MonoBehaviour
{
    Transform player;
    Vector3 direction;
    KnifesSpawner spawner;
    [SerializeField] float knifeHealth, knifeSpeed, knifeDamage;

    private void Start()
    {
        //Var init
        player = FindObjectOfType<PlayerController>().transform;
        direction = player.GetComponent<PlayerController>().direction;
        transform.eulerAngles = new Vector3(0, 0, UtilsClass.GetAngleFromVectorFloat(direction) - 135);
        spawner = FindObjectOfType<KnifesSpawner>();

        //Memory clean
        Destroy(gameObject, 5f);

        //Stats
        knifeHealth = spawner.powerInfo.health;
        knifeSpeed = spawner.powerInfo.speed;
        knifeDamage = spawner.powerInfo.damage;
    }

    private void Update()
    {
        //Knife movement
        transform.position += direction.normalized * knifeSpeed * Time.deltaTime;

        //Knife destroy
        if(knifeHealth <=0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyStats>().TakeDamage(knifeDamage);
            knifeHealth--;
        }
    }
}
