using UnityEngine;
using TMPro;


public class Thornmail : MonoBehaviour
{
    public PowerInfo powerInfo;
    public GameObject showDamage;




    private void Update()
    {
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
                powerInfo.powerDescription = "25% damage reflection";
                break;


            case 2:
                Debug.Log(powerInfo.name + "Subido a nivel 2");
                powerInfo.powerDescription = "50% damage reflection";
                powerInfo.multiplier = 0.25f;
                break;

            case 3:
                Debug.Log(powerInfo.name + "Subido a nivel 3");
                powerInfo.powerDescription = "75% damage reflection";
                powerInfo.multiplier = 0.50f;
                break;

            case 4:
                Debug.Log(powerInfo.name + "Subido a nivel 4");
                powerInfo.powerDescription = "100% damage reflection";
                powerInfo.multiplier = 0.75f;
                break;

            case 5:
                powerInfo.powerDescription = "110% damage reflection";
                powerInfo.multiplier = 1f;
                break;

            case 6:
                Debug.Log(powerInfo.name + "125% damage reflection");
                powerInfo.multiplier = 1.1f;
                break;
            case 7:
                powerInfo.multiplier = 1.25f;
                break;
        }
    }

    public void ReflectDamage(EnemyStats enemyStats, Transform enemyTransform)
    {
        enemyStats.health -= enemyStats.attackDamage * powerInfo.multiplier;
        var thornmailDamage = Instantiate(showDamage, enemyTransform.position, Quaternion.Euler(Vector3.zero));
        thornmailDamage.GetComponentInChildren<TMP_Text>().color = Color.yellow;
        thornmailDamage.GetComponent<DamageNumber>().damagePoints = enemyStats.attackDamage * FindObjectOfType<Thornmail>().GetComponent<PowerInfo>().multiplier;
    }
}
