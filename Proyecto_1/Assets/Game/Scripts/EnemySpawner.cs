using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefab;
    [SerializeField] float enemySpawnDelay = 1f;
    [SerializeField] float maxSpawnRadius;
    [SerializeField] float minSpawnRadius;
    [SerializeField] Transform player;
    public void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        StartCoroutine(EnemySpawnerRoutine());
    }

    private void Update()
    {
        if (GameManager.sharedInstance.enemiesKilled == 40)
        {
            enemySpawnDelay = 0.5f;
        }
        else if (GameManager.sharedInstance.enemiesKilled == 80)
        {
            enemySpawnDelay = 0.4f;
        }
        else if (GameManager.sharedInstance.enemiesKilled == 160)
        {
            enemySpawnDelay = 0.3f;
        }
        else if (GameManager.sharedInstance.enemiesKilled == 320)
        {
            enemySpawnDelay = 0.1f;
        }
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
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(player.transform.position, minSpawnRadius);
        Gizmos.DrawWireSphere(player.transform.position, maxSpawnRadius);
    }


}

