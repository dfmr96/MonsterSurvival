using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    CinemachineVirtualCamera vCam;
    void Start()
    {
        vCam = GetComponent<CinemachineVirtualCamera>();
    }

}
