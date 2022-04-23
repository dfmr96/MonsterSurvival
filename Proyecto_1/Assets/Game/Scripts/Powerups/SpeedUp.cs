using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    public float[] speedMultiplier;

    private void Start()
    {
        FindObjectOfType<PlayerController>().speed *= speedMultiplier[1];
    }
}

