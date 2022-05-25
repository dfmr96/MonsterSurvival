using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButtom : MonoBehaviour
{
    public GameObject panel;

    public void HideCreditScreen()
    {
        panel.SetActive(false);
    }
}
