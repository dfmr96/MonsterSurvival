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
            startPos = cam.ScreenToWorldPoint(Input.mousePosition); //Detectar donde se pulso la pantalla
        }

        if (Input.GetMouseButtonUp(0))
        {
            endPos = cam.ScreenToWorldPoint(Input.mousePosition); //Detectar donde se dejo de presionar la pantalla
            Debug.DrawLine(startPos, endPos, Color.red, 1f); 
            direction = endPos - startPos; //Direccion desde donde se pulso la pantalla hasta donde se solto
            Debug.Log(direction.magnitude);
            rb.velocity = direction.normalized * speed; //Da movimiento al jugador segun la direccion normalizada por la velocidad
        }

        if(direction.magnitude < 1)
        {
            rb.velocity = Vector2.zero; //Si la pantalla se presiono sin arrastrar lo suficiente el dedo, el jugador se detendrá;
        }
        vel = rb.velocity.magnitude;

    }
}
