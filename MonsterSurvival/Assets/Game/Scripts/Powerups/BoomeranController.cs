using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;


public class BoomeranController : MonoBehaviour
{
    Transform player;
    Vector3 direction;
    BoomeranSpawner spawner;
    [SerializeField] float boomeranHealth, boomeranSpeed, boomeranDamage;
    void Start()
    {
        //Var init
        player = FindObjectOfType<PlayerController>().transform;
        direction = player.GetComponent<PlayerController>().direction;
        transform.eulerAngles = new Vector3(0, 0, UtilsClass.GetAngleFromVectorFloat(direction));
        spawner = FindObjectOfType<BoomeranSpawner>();
        
        //Ignore player
        Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>(), GetComponent<Collider2D>());

        //Memory clean
        Destroy(gameObject, 5f);
        
        
        //Stats
        boomeranHealth = spawner.powerInfo.health;
        boomeranSpeed = spawner.powerInfo.speed;
        boomeranDamage = spawner.powerInfo.damage;

    }

    // Update is called once per frame
    void Update()
    {
        //Boomeran movement
        transform.position += direction.normalized * boomeranSpeed * Time.deltaTime;

        //Boomeran destroy
        if(boomeranHealth <= 0)
        {
            Destroy(gameObject);
        }
       

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Boomeran ricochets if collide with Enemy, make damage and then ricochet;
        if (collision.gameObject.CompareTag("Enemy"))
        {
            boomeranHealth--;
            collision.collider.GetComponent<EnemyStats>().TakeDamage(boomeranDamage);
            direction = Vector2.Reflect(direction, (Vector2)collision.contacts[0].normal);
        } else if (collision.gameObject.CompareTag("Breakable"))
        {
            boomeranHealth--;
            collision.collider.GetComponent<PotBreakable>().TakeDamage(boomeranDamage);
            direction = Vector2.Reflect(direction, (Vector2)collision.contacts[0].normal);

        }
    }


}
