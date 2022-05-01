using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifesSpawner : MonoBehaviour
{
    [SerializeField] float spawnRate;
    Transform player;
    [SerializeField] GameObject knifePrefab;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        StartCoroutine(KnifeSpawner());

    }

    IEnumerator KnifeSpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            Instantiate(knifePrefab, player.position, Quaternion.identity);
        }
    }
}
