using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DamageNumber : MonoBehaviour
{
    public float damageSpeed;
    public float damagePoints;
    public TMP_Text damageText;

    private void Start()
    {
        damageText.text = damagePoints.ToString();
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.5f, this.transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        damageText.text = damagePoints.ToString();
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + damageSpeed * Time.deltaTime, this.transform.position.z);
        Destroy(gameObject, 0.3f);
    }
}
