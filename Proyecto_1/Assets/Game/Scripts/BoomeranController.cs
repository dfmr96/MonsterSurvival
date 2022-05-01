using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;


public class BoomeranController : MonoBehaviour
{
    Transform player;
    Vector3 direction;
    [SerializeField] PowerInfo powerInfo;
    public float boomeranHealth;
    void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        direction = player.GetComponent<PlayerController>().direction;
        transform.eulerAngles = new Vector3(0, 0, UtilsClass.GetAngleFromVectorFloat(direction));
        boomeranHealth = powerInfo.health;
        Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction.normalized * powerInfo.speed * Time.deltaTime;

        if(boomeranHealth <= 0)
        {
            Destroy(gameObject);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            boomeranHealth--;
            collision.collider.GetComponent<EnemyStats>().TakeDamage(powerInfo.damage);
            direction = Vector2.Reflect(direction, (Vector2)collision.contacts[0].normal);
        }
    }
   
}
