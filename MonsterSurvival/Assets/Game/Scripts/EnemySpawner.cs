using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> enemyToSpawn;
    [SerializeField] List<GameObject> enemyPrefab;
    [SerializeField] List<GameObject> superEnemiesPrefabs;
    [SerializeField] float enemySpawnDelay;
    [SerializeField] float maxSpawnRadius;
    [SerializeField] float minSpawnRadius;
    [SerializeField] Transform player;
    [SerializeField] int maxEnemiesSpawning = 5;
    bool wave1Trigger = false;
    bool wave2Trigger = false;
    bool wave3Trigger = false;
    bool wave4Trigger = false;
    bool wave5Trigger = false;
    bool wave6Trigger = false;
    bool wave7Trigger = false;
    bool wave8Trigger = false;
    bool wave9Trigger = false;
    bool wave10Trigger = false;



    public void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        StartCoroutine(EnemySpawnerRoutine());
    }

    private void Update()
    {
        //SPAWN RATE BY TIME ELAPSED

        //if (GameManager.sharedInstance.enemiesKilled == 40)
        //{
        //    enemySpawnDelay = 0.5f;
        //}
        //else if (GameManager.sharedInstance.enemiesKilled == 80)
        //{
        //    enemySpawnDelay = 0.4f;
        //}
        //else if (GameManager.sharedInstance.enemiesKilled == 160)
        //{
        //    enemySpawnDelay = 0.3f;
        //}
        //else if (GameManager.sharedInstance.enemiesKilled == 320)
        //{
        //    enemySpawnDelay = 0.1f;
        //}

        //ENEMIES TO SPAWN BY TIME ELAPSED

        //WAVE 1

        //Agrega escarabajo

        //Enemigos: Murcielago y escarabajo
        if (GameManager.sharedInstance.timerMinutes == 1 && GameManager.sharedInstance.timerSeconds == 0)
        {

            if (wave1Trigger == false)
            {
                maxEnemiesSpawning++;
                enemyToSpawn.Add(enemyPrefab[1]);
                Debug.Log(enemyPrefab[1].name + "copiado a ToSpawn");
                SuperEnemySpawner(superEnemiesPrefabs[0]);
                wave1Trigger = true;
            }
        }

        //WAVE 2

        // Remueve Murcielago y agrega zombie

        //Enemigos: Escarabajo y zombie
        if (GameManager.sharedInstance.timerMinutes == 2 && GameManager.sharedInstance.timerSeconds == 0)
        {

            if (wave2Trigger == false)
            {
                maxEnemiesSpawning++;
                enemyToSpawn.Remove(enemyPrefab[0]);
                Debug.Log(enemyPrefab[0].name + " borrado de ToSpawn");
                enemyToSpawn.Add(enemyPrefab[2]);
                Debug.Log(enemyPrefab[2].name + " copiado a ToSpawn");
                wave2Trigger = true;
            }
        }

        //WAVE 3

        //Agrega Mano

        //Enemigos: escarabajo, Zombie y Mano

        if (GameManager.sharedInstance.timerMinutes == 3 && GameManager.sharedInstance.timerSeconds == 0)
        {

            if (wave3Trigger == false)
            {
                maxEnemiesSpawning++;
                enemyToSpawn.Add(enemyPrefab[3]);
                Debug.Log(enemyPrefab[3].name + "copiado a ToSpawn");
                enemySpawnDelay = 0.9f;
                wave3Trigger = true;
            }
        }

        //WAVE 4
        //Remueve escarabajo, agrega Perro
        //Enemigos: Zombie, mano, perro

        if (GameManager.sharedInstance.timerMinutes == 4 && GameManager.sharedInstance.timerSeconds == 0)
        {

            if (wave4Trigger == false)
            {
                maxEnemiesSpawning++;
                enemyToSpawn.Remove(enemyPrefab[1]);
                Debug.Log(enemyPrefab[1].name + " borrado de ToSpawn");
                enemyToSpawn.Add(enemyPrefab[4]);
                Debug.Log(enemyPrefab[4].name + " copiado a ToSpawn");
                enemySpawnDelay = 0.85f;
                wave4Trigger = true;
            }
        }

        //WAVE 5
        //Remueve: Zombie, mano
        //Enemigos: Perro

        if (GameManager.sharedInstance.timerMinutes == 5 && GameManager.sharedInstance.timerSeconds == 30)
        {

            if (wave5Trigger == false)
            {
                maxEnemiesSpawning++;
                enemyToSpawn.Remove(enemyPrefab[2]);
                enemyToSpawn.Remove(enemyPrefab[3]);
                Debug.Log(enemyPrefab[2].name + " borrado de ToSpawn");
                Debug.Log(enemyPrefab[3].name + " borrado de ToSpawn");
                enemySpawnDelay = 0.8f;
                wave5Trigger = true;
            }
        }

        //WAVE 6
        //Remueve: Perro, agrega ghoul y murcielago
        //Enemigos: Ghoul y murcielago

        if (GameManager.sharedInstance.timerMinutes == 6 && GameManager.sharedInstance.timerSeconds == 0)
        {

            if (wave6Trigger == false)
            {
                maxEnemiesSpawning++;
                enemyToSpawn.Remove(enemyPrefab[4]);
                Debug.Log(enemyPrefab[4].name + " borrado de ToSpawn");
                enemyToSpawn.Add(enemyPrefab[0]);
                Debug.Log(enemyPrefab[0].name + " copiado a ToSpawn");
                enemyToSpawn.Add(enemyPrefab[5]);
                Debug.Log(enemyPrefab[5].name + " copiado a ToSpawn");
                enemySpawnDelay = 0.75f;
                wave6Trigger = true;
            }
        }

        //WAVE 7
        //Remueve: Murcielago, agrega Ghastly y revenant
        //Enemigos: Ghoul, Ghastly y Revenant

        if (GameManager.sharedInstance.timerMinutes == 8 && GameManager.sharedInstance.timerSeconds == 0)
        {

            if (wave7Trigger == false)
            {
                maxEnemiesSpawning++;
                enemyToSpawn.Remove(enemyPrefab[0]);
                Debug.Log(enemyPrefab[0].name + " borrado de ToSpawn");
                enemyToSpawn.Add(enemyPrefab[6]);
                Debug.Log(enemyPrefab[6].name + " copiado a ToSpawn");
                enemyToSpawn.Add(enemyPrefab[7]);
                Debug.Log(enemyPrefab[7].name + " copiado a ToSpawn");
                enemySpawnDelay = 0.7f;
                wave7Trigger = true;
            }
        }

        //WAVE 8
        //Remueve: Ghoul
        //Enemigos: Ghastly y Revenant

        if (GameManager.sharedInstance.timerMinutes == 10 && GameManager.sharedInstance.timerSeconds == 0)
        {

            if (wave8Trigger == false)
            {
                maxEnemiesSpawning++;
                enemyToSpawn.Remove(enemyPrefab[5]);
                Debug.Log(enemyPrefab[5].name + " borrado de ToSpawn");
                enemySpawnDelay = 0.65f;
                wave8Trigger = true;
            }
        }

        //WAVE 9
        //Remueve: Ghastly
        //Enemigos: Revenant

        if (GameManager.sharedInstance.timerMinutes == 13 && GameManager.sharedInstance.timerSeconds == 0)
        {

            if (wave9Trigger == false)
            {
                maxEnemiesSpawning++;
                enemyToSpawn.Remove(enemyPrefab[6]);
                Debug.Log(enemyPrefab[6].name + " borrado de ToSpawn");
                wave9Trigger = true;
                enemySpawnDelay = 0.4f;
            }
        }

        //WAVE 10
        //Remueve: Revenant, agrega Murcielago
        //Enemigos: Murcielago

        if (GameManager.sharedInstance.timerMinutes == 15 && GameManager.sharedInstance.timerSeconds == 0)
        {

            if (wave10Trigger == false)
            {
                maxEnemiesSpawning++;
                enemyToSpawn.Remove(enemyPrefab[7]);
                Debug.Log(enemyPrefab[7].name + " borrado de ToSpawn");
                enemyToSpawn.Add(enemyPrefab[0]);
                Debug.Log(enemyPrefab[0].name + " copiado a ToSpawn");

                enemySpawnDelay = 0.3f;
                wave10Trigger = true;
            }
        }

    }
    IEnumerator EnemySpawnerRoutine()
    {
        while (true)
        {
            int randomEnemiesNumber = Random.Range(0, maxEnemiesSpawning + 1);
            for (int i = 0; i < randomEnemiesNumber; i++)
            {
                Vector2 randomPosition = (Vector2)player.transform.position + Random.insideUnitCircle.normalized * Random.Range(minSpawnRadius, maxSpawnRadius);
                int random = Random.Range(0, enemyToSpawn.Count);
                Instantiate(enemyToSpawn[random], randomPosition, Quaternion.identity);
            }
            yield return new WaitForSeconds(enemySpawnDelay);
        }
    }

    void SuperEnemySpawner(GameObject superEnemy)
    {
        Vector2 randomPosition = (Vector2)player.transform.position + Random.insideUnitCircle.normalized * Random.Range(minSpawnRadius, maxSpawnRadius);
        Instantiate(superEnemy, randomPosition, Quaternion.identity);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(player.transform.position, minSpawnRadius);
        Gizmos.DrawWireSphere(player.transform.position, maxSpawnRadius);
    }


}

