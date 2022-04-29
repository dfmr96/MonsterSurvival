using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Transform player;
    PlayerStats playerStats;
    Vector2 direction;
    [SerializeField] EnemyStats enemyStats;
    public float attackDelayCounter = 0f;
    bool canAttack;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        playerStats = FindObjectOfType<PlayerStats>();
        enemyStats = gameObject.GetComponent<EnemyStats>();

    }

    // Update is called once per frame
    void Update()
    {
        direction = player.position - transform.position; //Direccion hacia donde esta el jugador
        transform.position += (Vector3)direction.normalized * enemyStats.speed * Time.deltaTime; //Movimiento en direccion al jugador detectado
        attackDelayCounter += Time.deltaTime;

        if (attackDelayCounter > enemyStats.attackDelay && canAttack)
        {
            playerStats.TakeDamage(enemyStats.attackDamage);
            attackDelayCounter = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canAttack = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canAttack = false;
        }
    }
}
