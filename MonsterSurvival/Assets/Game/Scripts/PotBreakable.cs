using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotBreakable : MonoBehaviour
{
    public float potHealth = 1;
    [SerializeField] GameObject[] droppeablePrefab;
    [SerializeField] Animator anim;
    bool isBroken = false;

    private void Update()
    {
        if (potHealth <= 0 && !isBroken)
        {
            isBroken = true;
            anim.SetBool("isBroken", true);
            StartCoroutine("SpawnItem");
            Destroy(gameObject, 5f);
        }
    }
    public void TakeDamage(float damage)
    {
        potHealth -= damage;

    }

    IEnumerator SpawnItem()
    {
        int random = Random.Range(0, droppeablePrefab.Length);
        yield return new WaitForSeconds(1);
        Instantiate(droppeablePrefab[random], transform.position, Quaternion.identity);
    }
}
