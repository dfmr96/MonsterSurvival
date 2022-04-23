using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int health = 2;
    public float speed = 3f;
    public float attackSpeed = 1f, attackDelay = 2f;
    public float attackDamage = 1;
    [SerializeField] GameObject gemPrefab;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Instantiate(gemPrefab, gameObject.transform.position, Quaternion.identity);
            GameManager.sharedInstance.enemiesKilled++;
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int Damage)
    {
        health -= Damage;
    }
}
