using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Transform player;
    [SerializeField] float speed = 3f;
    Vector2 direction;
    [SerializeField] int health = 2;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        direction = player.position - transform.position; //Direccion hacia donde esta el jugador
        transform.position += (Vector3)direction.normalized * speed * Time.deltaTime; //Movimiento en direccion al jugador detectado

        if(health <=0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
