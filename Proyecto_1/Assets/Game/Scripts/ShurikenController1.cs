using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenController1 : MonoBehaviour
{
    Transform player;
    [SerializeField] float radius;
    [SerializeField] int angularSpeed;
    [SerializeField] float angles;
    [SerializeField] int damage;
    [SerializeField] int shurikenHealth = 5;
    Vector3 vectorPosition;
    float timeCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime * angularSpeed;
        vectorPosition = new Vector3(Mathf.Cos(timeCounter) * radius, Mathf.Sin(timeCounter) * radius, 0);
        transform.position = vectorPosition + player.position;

        if(shurikenHealth <= 0)
        {
            Destroy(gameObject);
            FindObjectOfType<ShurikensSpawner>().shurikenAmount--;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyStats>().TakeDamage(damage);
            shurikenHealth--;
        }
    }
}
