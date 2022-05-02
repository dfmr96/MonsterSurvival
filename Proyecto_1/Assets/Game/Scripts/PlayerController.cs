using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 startPos;
    Vector2 endPos;
    public Vector3 direction,fingerDirection;
    public float speed = 5f;
    [SerializeField] Camera cam;
    public SpriteRenderer sprite;
    
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            startPos = transform.position; //Detectar donde se pulso la pantalla
            endPos = cam.ScreenToWorldPoint(Input.mousePosition);
            direction = endPos - startPos;
            rb.velocity = direction.normalized * speed; //Da movimiento al jugador segun la direccion normalizada por la velocidad
        } else
        {
            rb.velocity = Vector2.zero; //Si la pantalla se presiono sin arrastrar lo suficiente el dedo, el jugador se detendrá;
        }

        if( direction.x < 0)
        {
            sprite.flipX = true;
        } else
        {
            sprite.flipX = false;
        }
    }
}
