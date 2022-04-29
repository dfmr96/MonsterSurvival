using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseUp : MonoBehaviour
{
    public float[] defenseBonus;
    [SerializeField] PowerInfo powerInfo;

    private void Update()
    {
    powerInfo.defense = defenseBonus[powerInfo.currentLevel];   
    }
}
