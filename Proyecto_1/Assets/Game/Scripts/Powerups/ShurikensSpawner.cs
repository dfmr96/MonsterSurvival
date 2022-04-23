using System.Collections;
using UnityEngine;

public class ShurikensSpawner : MonoBehaviour
{
    [SerializeField] float spawnRate;
    Transform player;
    [SerializeField] GameObject shurikenPrefab;
    public int shurikenAmount = 0;
    public bool canSpawnShuriken;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        StartCoroutine(ShurikenSpawner());

    }

    IEnumerator ShurikenSpawner()
    {
        while (true)
        {
            {
                yield return new WaitForSeconds(spawnRate);
                Instantiate(shurikenPrefab, player.position, Quaternion.identity);
                shurikenAmount++;
            }

        }
    }
}
