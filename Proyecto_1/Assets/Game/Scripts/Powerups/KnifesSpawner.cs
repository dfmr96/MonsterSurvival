using UnityEngine;

public class KnifesSpawner : MonoBehaviour
{
    public PowerInfo powerInfo;
    Transform player;
    [SerializeField] GameObject knifePrefab;
    [SerializeField] float coolDownCounter;
    void Start()
    {
        //Var init
        player = FindObjectOfType<PlayerController>().transform;
        powerInfo = GetComponent<PowerInfo>();
        coolDownCounter = 0f;

    }

    public void Update()
    {
        //Cooldown counter
        coolDownCounter += Time.deltaTime;

        //Countdown reset and create 
        if (coolDownCounter >= powerInfo.coolDown)
        {
            Instantiate(knifePrefab, player.position, Quaternion.identity);
            coolDownCounter = 0f;

        }

        //Check level up
        if (powerInfo.leveledUp)
        {
            UpdateStats();
            powerInfo.leveledUp = false;
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
                powerInfo.powerDescription = "Increase the number of enemies that can be passed through by 1";
                powerInfo.damage++;
                break;

            case 3:
                Debug.Log(powerInfo.name + "Subido a nivel 3");
                powerInfo.powerDescription = "Increase speed by 1";
                powerInfo.health++;
                break;

            case 4:
                Debug.Log(powerInfo.name + "Subido a nivel 4");
                powerInfo.powerDescription = "Decrease cooldown by 25%";
                powerInfo.speed++;
                break;

            case 5:
                Debug.Log(powerInfo.name + "Subido a nivel 5");
                powerInfo.coolDown *= 0.75f;
                break;


        }
    }
}
