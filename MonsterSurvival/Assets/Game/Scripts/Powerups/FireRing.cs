using UnityEngine;

public class FireRing : MonoBehaviour
{
    public Transform player;
    [SerializeField] Collider2D[] enemiesInsideArea;
    [SerializeField] LayerMask mask;
    [SerializeField] float coolDownCounter;
    [SerializeField] PowerInfo powerInfo;
    [SerializeField] Animator animator;

    public void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        transform.position = player.position;
        coolDownCounter = 0;
        transform.localScale = new Vector3(powerInfo.radius, powerInfo.radius, powerInfo.radius);
    }
    private void Update()
    {
        transform.position = player.position;
        coolDownCounter += Time.deltaTime;

        if (coolDownCounter >= powerInfo.coolDown)
        {
            animator.SetTrigger("canAttack");
            //animator.SetBool("isAttacking", true);
            DamageEnemies();
            coolDownCounter = 0;
        }
        animator.SetBool("isAttacking", false);

        if (powerInfo.leveledUp)
        {
            UpdateStats();
            powerInfo.leveledUp = false;
        }
    }

    public void DamageEnemies()
    {
        enemiesInsideArea = Physics2D.OverlapCircleAll(transform.position, powerInfo.radius, mask);

        foreach (Collider2D collision in enemiesInsideArea)
        {
            if (collision.CompareTag("Enemy"))
            {
                collision.GetComponent<EnemyStats>().TakeDamage(powerInfo.damage);
            }
            else if (collision.CompareTag("Breakable"))
            {
                collision.GetComponent<PotBreakable>().TakeDamage(powerInfo.damage);
            }

        }


    }

    public void UpdateStats()
    {
        switch (powerInfo.currentLevel)
        {
            case 1:
                Debug.Log(powerInfo.name + "Nivel 1");
                powerInfo.powerDescription = "Increase damage by 5";
                break;


            case 2:
                Debug.Log(powerInfo.name + "Subido a nivel 2");
                powerInfo.powerDescription = "Decrease cooldown by 25%";
                powerInfo.damage += 5;
                break;

            case 3:
                Debug.Log(powerInfo.name + "Subido a nivel 3");
                powerInfo.powerDescription = "Increase damage by 5";
                powerInfo.coolDown *= 0.75f;
                break;

            case 4:
                Debug.Log(powerInfo.name + "Subido a nivel 4");
                powerInfo.powerDescription = "Decrease cooldown by 50%";
                powerInfo.damage += 5;
                break;

            case 5:
                powerInfo.powerDescription = "Increase damage by 5";
                powerInfo.coolDown *= 0.5f;
                break;

            case 6:
                powerInfo.powerDescription = "Increase damage by 5";
                powerInfo.damage += 5;
                break;

            case 7:
                powerInfo.damage += 5;
                break;

        }


    }
}
