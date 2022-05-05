using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth;
    public float health;
    public int currentLevel;
    public int currentExp;
    public int[] expToLevelUp;
    public GameObject showDamage;

    private void Start()
    {
        health = maxHealth;
    }
    // Update is called once per frame
    void Update()
    {
        if (currentLevel >= expToLevelUp.Length)
        {
            return;
        }

        if (currentExp >= expToLevelUp[currentLevel])
        {
            currentLevel++;
            if (currentLevel != 1)
            {
                GameManager.sharedInstance.levelUpScreenManager.ShowLevelUpScreen();
            }
        }

        if (health <= 0)
        {
            GameManager.sharedInstance.CallGameOverScreen();
        }
        if(health>maxHealth)
        {
            health = maxHealth;
        }
    }

    public void AddExperience(int exp)
    {
        currentExp += exp;
    }

    public void TakeDamage(float damage)
    {
        if (GameObject.FindGameObjectWithTag("Defense Up") != null)
        {
        float defense = FindObjectOfType<DefenseUp>().GetComponentInParent<PowerInfo>().defense;
            if (defense > damage)
            {
                damage = 0f;
            }
            else
            {
                damage -= defense;
            }
        }
        var damageShown = Instantiate(showDamage, transform.position, Quaternion.Euler(Vector3.zero));
        damageShown.GetComponentInChildren<TMP_Text>().color = Color.red;
        damageShown.GetComponent<DamageNumber>().damagePoints = damage;
        health -= damage;
    }
}
