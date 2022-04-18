using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 startPos;
    Vector3 endPos;
    Vector3 direction;
    [SerializeField] int speed = 5;
    [SerializeField] Camera cam;
    [SerializeField] float vel;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            startPos = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            endPos = cam.ScreenToWorldPoint(Input.mousePosition);
            Debug.DrawLine(startPos, endPos, Color.red, 1f);
            direction = endPos - startPos;
            Debug.Log(direction.magnitude);
            rb.velocity = direction.normalized * speed;
        }

        if(direction.magnitude < 1)
        {
            rb.velocity = Vector2.zero;
        }
        vel = rb.velocity.magnitude;

    }
}
