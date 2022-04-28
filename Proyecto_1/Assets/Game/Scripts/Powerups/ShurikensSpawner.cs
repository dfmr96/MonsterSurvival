using System.Collections;
using UnityEngine;

public class ShurikensSpawner : MonoBehaviour
{

    int numberOfObjects = 5;
    [SerializeField] float spawnRate;
    Transform player;
    [SerializeField] GameObject shurikenPrefab;
    [SerializeField] GameObject[] shurikenPrefabs;
    public int shurikenAmount = 0;
    public bool canSpawnShuriken;
    System.Threading.Timer timer;

    float timeCounter = 0;
    bool needRespawn = false;
	float needToRespawnTime = 0;

    // Start is called before the first frame update
    void Start()
    {
    	shurikenPrefabs = new GameObject[numberOfObjects];
        player = FindObjectOfType<PlayerController>().transform;
        // StartCoroutine(ShurikenSpawner());

		crearAllShuriken();
		// crearShurikenAfter(5000);
    }

  //   void activatedAllShurikensAfter(int miliseconds) {
  //   	Debug.Log("testing Timer before");
		// timer = new System.Threading.Timer((obj) => {
  //       	canSpawn = true;
	 //        crearAllShuriken();
  //       	timer.Dispose();
	 //    }, null, miliseconds, 1000);
  //   }

    void crearAllShuriken() {
    	int radius = 3;
    	for (int i = 0; i < numberOfObjects; i++)  {

			float angle = i * Mathf.PI * 2 / numberOfObjects;
			float x = Mathf.Cos(angle) * radius;
			float z = Mathf.Sin(angle) * radius;
			Vector3 pos = new Vector3(x, z, 0);

	        GameObject shuriken = Instantiate(shurikenPrefab, pos, Quaternion.identity);  		
    		shurikenPrefabs[i] = shuriken;
    	}
    }

    void Update() {
		Transform player = FindObjectOfType<PlayerController>().transform;
		int radius = 3;
		timeCounter += Time.deltaTime;

		var allNotActive = true;

		for (int i = 0; i < numberOfObjects; i++)  {
			float angle = i * Mathf.PI * 2 / numberOfObjects;
			float x = Mathf.Cos(angle + timeCounter) * radius;
			float z = Mathf.Sin(angle + timeCounter) * radius;
			Vector3 pos = new Vector3(x, z, 0);

			shurikenPrefabs[i].transform.position = pos + player.position;

			allNotActive = allNotActive && !shurikenPrefabs[i].activeSelf;
		}

		if (allNotActive && needToRespawnTime == 0) {
			needToRespawnTime = Time.fixedTime;
			needRespawn = true;
		}

			
		if (needRespawn && (Time.fixedTime - needToRespawnTime > 5.0)) {
			for (int i = 0; i < numberOfObjects; i++)  {
				 shurikenPrefabs[i].GetComponent<ShurikenController1>().shurikenHealth = 5;
				 shurikenPrefabs[i].SetActive(true);
			}
			needRespawn = false;
			needToRespawnTime = 0;
		}
    }

    // IEnumerator ShurikenSpawner()
    // {
    //     while (true)
    //     {
    //         {
    //             // yield return new WaitForSeconds(spawnRate);
    //             // Instantiate(shurikenPrefab, player.position, Quaternion.identity);
    //             // shurikenAmount++;
    //         }

    //     }
    // }
}
