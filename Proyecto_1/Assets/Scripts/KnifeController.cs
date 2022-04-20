using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
public class KnifeController : MonoBehaviour
{
    Transform player;
    Vector3 direction;
    [SerializeField] int speed = 1, damage= 1;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        direction = player.GetComponent<PlayerController>().direction;
        transform.eulerAngles = new Vector3(0, 0, UtilsClass.GetAngleFromVectorFloat(direction));
    }

    private void Update()
    {
        transform.position += direction.normalized * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Enemigo herido");
            collision.GetComponent<EnemyStats>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
