using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int health = 2;
     public float speed = 3f;
    [SerializeField] int expWhenKilled = 5;
    public float attackSpeed = 1f, attackDelay = 2f;
    public int attackDamage = 1;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().AddExperience(expWhenKilled);
            Destroy(gameObject);
            GameManager.sharedInstance.enemiesKilled++;
        }
    }

    public void TakeDamage(int Damage)
    {
        health -= Damage;
    }
}
