using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (FindObjectOfType<GameManager>() != null)
        {
            DontDestroyOnLoad(this.transform.gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }
}
