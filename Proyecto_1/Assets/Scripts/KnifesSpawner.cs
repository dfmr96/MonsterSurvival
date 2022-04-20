using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifesSpawner : MonoBehaviour
{
    [SerializeField] float spawnRate;
    Transform player;
    Vector3 direction;
    [SerializeField] GameObject knifePrefab;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        direction = player.GetComponent<PlayerController>().direction;
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
