using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Transform player;
    [SerializeField] float speed = 3f;
    Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        direction = player.position - transform.position;
        transform.position += (Vector3)direction.normalized * speed * Time.deltaTime;
    }
}
