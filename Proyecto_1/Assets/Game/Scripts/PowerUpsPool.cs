using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsPool : MonoBehaviour
{
    public List<GameObject> powerUps;
    public List<GameObject> resetPowerUps;

    public void CopyList()
    {
        powerUps = new List<GameObject>(resetPowerUps);
    }

}
