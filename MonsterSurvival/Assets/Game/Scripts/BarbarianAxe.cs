using UnityEngine;

public class BarbarianAxe : MonoBehaviour
{
    Transform player;
    [SerializeField] PowerInfo powerInfo;
    [SerializeField] float coolDownCounter;
    Collider2D axeSlash;
    SpriteRenderer sprite;
    Vector3 direction;
    [SerializeField] Animator animator;
    private void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        direction = player.GetComponent<PlayerController>().direction;
        transform.position = player.position;
        coolDownCounter = 0;
        axeSlash = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        coolDownCounter += Time.deltaTime;
        direction = player.GetComponent<PlayerController>().direction;
        if (coolDownCounter >= powerInfo.coolDown)
        {
            if (direction.x < 0)
            {
                transform.position = player.position + new Vector3(-2, 0, 0);
                transform.localRotation = Quaternion.Euler(0, 0, 45);
                animator.SetTrigger("Attack");
                axeSlash.enabled = true;
            }
            else
            {
                transform.position = player.position + new Vector3(2, 0, 0);
                transform.localRotation = Quaternion.Euler(0, 180, 45);
                animator.SetTrigger("Attack");
                axeSlash.enabled = true;
            }
            coolDownCounter = 0;
        }
        else
        {
            axeSlash.enabled = false;
            //sprite.enabled = false;
            animator.SetBool("isAttacking", false);
        }

        if (powerInfo.leveledUp)
        {
            UpdateStats();
            powerInfo.leveledUp = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyStats>().TakeDamage(powerInfo.damage);
        }
    }

    public void UpdateStats()
    {
        switch (powerInfo.currentLevel)
        {
            case 1:
                Debug.Log(powerInfo.name + "Nivel 1");
                powerInfo.powerDescription = "Increase damage by 1";
                break;


            case 2:
                Debug.Log(powerInfo.name + "Subido a nivel 2");
                powerInfo.powerDescription = "Increase damage by 2";
                powerInfo.damage++;
                break;

            case 3:
                Debug.Log(powerInfo.name + "Subido a nivel 3");
                powerInfo.powerDescription = "Decrease cooldown by 25%";
                powerInfo.damage += 2;
                break;

            case 4:
                Debug.Log(powerInfo.name + "Subido a nivel 4");
                powerInfo.powerDescription = "Decrease cooldown by 25%";
                powerInfo.coolDown *= 0.75f;
                break;

            case 5:
                Debug.Log(powerInfo.name + "Subido a nivel 5");
                powerInfo.coolDown *= 0.75f;
                break;

            case 6:
                Debug.Log(powerInfo.name + "Subido a nivel 6");
                powerInfo.damage += 2;
                break;
            case 7:
                Debug.Log(powerInfo.name + "Subido a nivel 7");
                powerInfo.damage += 2;
                break;


        }
    }
}
