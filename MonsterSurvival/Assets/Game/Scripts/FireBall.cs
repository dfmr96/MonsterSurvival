using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;


public class FireBall : MonoBehaviour
{
    Transform player;
    Vector3 direction;
    FireScepter spawner;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        spawner = FindObjectOfType<FireScepter>();
        direction = spawner.enemyDirection;
        Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>(), GetComponent<Collider2D>());
        transform.eulerAngles = new Vector3(0, 0, UtilsClass.GetAngleFromVectorFloat(direction));
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        transform.position += direction.normalized * spawner.GetComponent<PowerInfo>().speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.collider.GetComponent<EnemyStats>().TakeDamage(spawner.GetComponent<PowerInfo>().damage);
        }
        else if (collision.gameObject.CompareTag("Breakable"))
        {
            collision.collider.GetComponent<PotBreakable>().TakeDamage(spawner.GetComponent<PowerInfo>().damage);
        }
    }
}
