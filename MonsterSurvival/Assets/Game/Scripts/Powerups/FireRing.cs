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


}
