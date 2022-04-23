using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : MonoBehaviour
{
    public float[] healthMultiplier;
    public string skillName = "HealthUp";

    private void Start()
    {
        FindObjectOfType<PlayerStats>().maxHealth *= healthMultiplier[1];
    }
}
