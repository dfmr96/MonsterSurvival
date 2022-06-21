using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float health = 2.00f;
    public float attackDamage = 1f;
    public float speed = 3f;
    public float attackDelay = 2f;
    public GameObject showDamage;
    bool enemyWounded = false;
    public Material unwounded, wounded; 
    [SerializeField] GameObject gemPrefab;
    AudioSource damageSound;



    // Start is called before the first frame update
    void Start()
    {
        damageSound = GetComponent<AudioSource>();
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
        if (!enemyWounded)
        {
            this.gameObject.GetComponent<SpriteRenderer>().material = unwounded;
        }
    }

    public void TakeDamage(float Damage)
    {
        damageSound.Play();
        health -= Damage;
        var damageShown = Instantiate(showDamage , transform.position, Quaternion.Euler(Vector3.zero));
        damageShown.GetComponent<DamageNumber>().damagePoints = Damage;
        enemyWounded = true;
        StartCoroutine("ToogleSpriteColor");
    }

    IEnumerator ToogleSpriteColor ()
    { 
        this.gameObject.GetComponent<SpriteRenderer>().material = wounded;
        yield return new WaitForSeconds(0.25f);
        enemyWounded = false;
    }
}
