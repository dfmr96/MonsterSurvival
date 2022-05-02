using UnityEngine;

public class ShurikensSpawner : MonoBehaviour
{
    public PowerInfo powerInfo;
    Transform player;
    [SerializeField] GameObject shurikenPrefab;
    [SerializeField] GameObject[] shurikenPrefabs;
    public int shurikenAmount = 0;
    public bool canSpawnShuriken;
    float timeCounter = 0;
    bool needRespawn = false;
    float needToRespawnTime = 0;


    void Start()
    {
        //var init
        shurikenPrefabs = new GameObject[powerInfo.projectiles];
        player = FindObjectOfType<PlayerController>().transform;

        crearAllShuriken();
    }

    private void Update()

    {

        //Check level up
        if (powerInfo.leveledUp)
        {
            UpdateStats();
            powerInfo.leveledUp = false;
        }

        timeCounter += Time.deltaTime;
        float angularSpeed = powerInfo.angularSpeed * timeCounter;
        var allNotActive = true;

        for (int i = 0; i < powerInfo.projectiles; i++)
        {
            float angle = i * Mathf.PI * 2 / powerInfo.projectiles;
            float x = Mathf.Cos(angle + angularSpeed) * powerInfo.radius;
            float y = Mathf.Sin(angle + angularSpeed) * powerInfo.radius;
            Vector3 pos = new Vector3(x, y, 0);

            shurikenPrefabs[i].transform.position = pos + player.position;

            allNotActive = allNotActive && !shurikenPrefabs[i].activeSelf;
        }

        if (allNotActive && needToRespawnTime == 0)
        {
            needToRespawnTime = Time.fixedTime;
            needRespawn = true;
        }


        if (needRespawn && (Time.fixedTime - needToRespawnTime > powerInfo.coolDown))
        {
            for (int i = 0; i < powerInfo.projectiles; i++)
            {
                shurikenPrefabs[i].GetComponent<ShurikenController>().shurikenHealth = powerInfo.health;
                shurikenPrefabs[i].SetActive(true);
            }
            needRespawn = false;
            needToRespawnTime = 0;
        }
    }
    void crearAllShuriken()
    {

        for (int i = 0; i < powerInfo.projectiles; i++)
        {

            float angle = i * Mathf.PI * 2 / powerInfo.projectiles;
            float x = Mathf.Cos(angle) * powerInfo.radius;
            float z = Mathf.Sin(angle) * powerInfo.radius;
            Vector3 pos = new Vector3(x, z, 0);

            GameObject shuriken = Instantiate(shurikenPrefab, pos, Quaternion.identity);
            shurikenPrefabs[i] = shuriken;
        }
    }

    public void UpdateStats()
    {
        switch (powerInfo.currentLevel)
        {
            case 1:
                Debug.Log(powerInfo.name + "Nivel 1");
                powerInfo.powerDescription = "Increase damage by 1";
                break;


            case 2:
                Debug.Log(powerInfo.name + "Subido a nivel 2");
                powerInfo.powerDescription = "Increase shuriken health by 1";
                powerInfo.damage++;
                break;

            case 3:
                Debug.Log(powerInfo.name + "Subido a nivel 3");
                powerInfo.powerDescription = "Increase speed by 40%";
                powerInfo.health++;
                break;

            case 4:
                Debug.Log(powerInfo.name + "Subido a nivel 4");
                powerInfo.powerDescription = "Decrease cooldown by 25%";
                powerInfo.angularSpeed *= 1.4f;
                break;

            case 5:
                Debug.Log(powerInfo.name + "Subido a nivel 5");
                powerInfo.coolDown *= 0.75f;
                break;


        }
    }
}
