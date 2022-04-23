using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpGem : MonoBehaviour
{
    [SerializeField] int exp = 5;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            if (collision.CompareTag("GemTaker"))
            {
            Debug.Log("Gema recogida");
            collision.GetComponentInParent<PlayerStats>().AddExperience(exp);
            Destroy(gameObject);
            }
        }
    }
}
