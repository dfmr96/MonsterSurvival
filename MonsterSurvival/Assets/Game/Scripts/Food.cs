using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Food : MonoBehaviour
{
    [SerializeField] float healthRecovery;
    public GameObject showHealthRecovery;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerStats>().health += healthRecovery;
            var damageShown = Instantiate(showHealthRecovery, transform.position, Quaternion.Euler(Vector3.zero));
            damageShown.GetComponentInChildren<TMP_Text>().color = Color.green;
            damageShown.GetComponent<DamageNumber>().damagePoints = healthRecovery;
            Destroy(gameObject);
        }
    }
}
