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
    public int shurikenHealth = 5;
    Vector3 vectorPosition;    // Start is called before the first frame update

    // Vector3 originalPosition;

    void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        // originalPosition = transform.position;
        // timeCounter += Time.deltaTime * angularSpeed;
        // vectorPosition = new Vector3(Mathf.Cos(timeCounter) * radius, Mathf.Sin(timeCounter) * radius, 0);
        // transform.position = player.position;
    }

    // Update is called once per frame
    void Update()
    {
        // timeCounter += Time.deltaTime * angularSpeed;
        // vectorPosition = new Vector3(Mathf.Cos(timeCounter) * radius, Mathf.Sin(timeCounter) * radius, 0);
        // transform.position = originalPosition + player.position;

        if(shurikenHealth <= 0)
        {
            // Destroy(gameObject);
            gameObject.SetActive(false);
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
