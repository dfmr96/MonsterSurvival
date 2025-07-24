using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] potPrefab;
    [SerializeField] float potSpawnDelay, maxSpawnRadius, minSpawnRadius;
    [SerializeField] Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        StartCoroutine(PotSpawnerRoutine());

    }

    IEnumerator PotSpawnerRoutine()
    {
        while (true)
        {
            Vector2 randomPosition = (Vector2)player.transform.position + Random.insideUnitCircle.normalized * Random.Range(minSpawnRadius, maxSpawnRadius);
            int random = Random.Range(0, potPrefab.Length);
            Instantiate(potPrefab[random], randomPosition, Quaternion.identity);
            yield return new WaitForSeconds(potSpawnDelay);
        }
    }
}
