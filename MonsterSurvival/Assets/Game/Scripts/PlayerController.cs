using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    float h; //informacion del eje horizontal del juegador
    float v; //informacion del eje vertical del jugador
    Rigidbody2D rb;
    //Vector2 startPos;
    //Vector2 endPos;
    // public Vector3 direction, fingerDirection;
    public float speed = 5f;
    [SerializeField] Camera cam;
    public SpriteRenderer sprite;
    public Vector2 direction;
    public Vector2 lastDirection;
    public Joystick joystick;
    public GameObject joystickGO;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //if(Input.GetMouseButton(0))
        //{
        //    startPos = transform.position; //Detectar donde se pulso la pantalla
        //    endPos = cam.ScreenToWorldPoint(Input.mousePosition);
        //    direction = endPos - startPos;
        //    rb.velocity = direction.normalized * speed; //Da movimiento al jugador segun la direccion normalizada por la velocidad
        //} else
        //{
        //    rb.velocity = Vector2.zero; //Si la pantalla se presiono sin arrastrar lo suficiente el dedo, el jugador se detendrá;
        //}

        //if( direction.x < 0)
        //{
        //    sprite.flipX = true;
        //} else
        //{
        //    sprite.flipX = false;
        //}

        //Movimiento del jugador
#if UNITY_ANDROID
        {
            h = joystick.Horizontal;
            v = joystick.Vertical;
            joystickGO.SetActive(true);

        }
#else
        {
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");
        }
#endif

        direction.x = h;
        direction.y = v;
        rb.velocity = speed * direction.normalized;
        if (direction != Vector2.zero)
        {
            lastDirection = direction;
        }


        if (lastDirection.x < 0)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }

        if (direction == Vector2.zero)
        {
            direction = lastDirection;
        }
    }
}

