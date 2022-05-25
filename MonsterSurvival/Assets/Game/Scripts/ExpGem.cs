using UnityEngine;

public class ExpGem : MonoBehaviour
{
    [SerializeField] float exp = 5;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GemTaker"))
        {

            collision.GetComponentInParent<PlayerStats>().AddExperience(exp);
            AudioManager.sharedInstance.GemPicked();
            Destroy(gameObject);
        }
    }
}
