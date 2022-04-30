using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] foodPrefab;
    [SerializeField] float foodSpawnDelay, maxSpawnRadius, minSpawnRadius;
    [SerializeField] Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        StartCoroutine(FoodSpawnerRoutine());

    }

    IEnumerator FoodSpawnerRoutine()
    {
        while (true)
        {
            Vector2 randomPosition = (Vector2)player.transform.position + Random.insideUnitCircle.normalized * Random.Range(minSpawnRadius, maxSpawnRadius);
            int random = Random.Range(0, foodPrefab.Length);
            Instantiate(foodPrefab[random], randomPosition, Quaternion.identity);
            yield return new WaitForSeconds(foodSpawnDelay);
        }
    }
}
