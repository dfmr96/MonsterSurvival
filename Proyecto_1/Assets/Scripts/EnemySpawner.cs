using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefab;
    [SerializeField] int enemySpawnDelay = 10;
    [SerializeField] float maxSpawnRadius;
    [SerializeField] float minSpawnRadius;
    [SerializeField] Transform player;
    public void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        StartCoroutine(EnemySpawnerRoutine());
    }
    IEnumerator EnemySpawnerRoutine()
    {
        while (true)
        {
            Vector2 randomPosition = (Vector2)player.transform.position + Random.insideUnitCircle.normalized * Random.Range(minSpawnRadius, maxSpawnRadius);
            int random = Random.Range(0, enemyPrefab.Length);
            Instantiate(enemyPrefab[random], randomPosition, Quaternion.identity);
            yield return new WaitForSeconds(enemySpawnDelay);
        }
    }
    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(player.transform.position, minSpawnRadius);
        Gizmos.DrawWireSphere(player.transform.position, maxSpawnRadius);
    }
    */
}
