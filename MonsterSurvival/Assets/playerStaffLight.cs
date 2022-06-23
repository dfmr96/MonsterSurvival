using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStaffLight : MonoBehaviour
{
    PlayerController playerController;
    Vector3 tP;
    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        tP = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.direction.x < 0)
        {
            tP.x = -0.75f;
        } else
        {
            tP.x= 0.75f;
        }
    }
}
