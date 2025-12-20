using Unity.VisualScripting;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float vMovimiento = 5f;

   //El punto al que queremos que el jugador se desplace en cada movimiento, 
   // con el fin de que siempre esté en los márgenes de una celda
    [SerializeField]
    private Transform movePoint;

    //La capa con la cual va a colisionar nuestro personaje
    [SerializeField]
    private LayerMask colisionar;

    [SerializeField]
    private static string ultimaDireccion = "right";

    [SerializeField]
    private static Vector2 posicion = new Vector2(0,0);

    [SerializeField]
    private Animator animator;

    private int direccion = 1;

    int filtroLayerMask;
    
    void Start()
    {
        //para que se mueva el movepoint y el jugador lo siga, si no al moverse pj se movería movepoint
        movePoint.parent = null;

        
        int colisionLayer = LayerMask.NameToLayer("Colision");
        int aguaLayer = LayerMask.NameToLayer("Agua");
        int arbolesLayer = LayerMask.NameToLayer("Arboles");
        int piedrasLayer = LayerMask.NameToLayer("Piedras");
        //int otrosLayer = LayerMask.NameToLayer("Otros");

        int colisionMask = 1 << colisionLayer;
        int aguaMask = 1 << aguaLayer;
        int arbolesMask = 1 << arbolesLayer;
        int piedrasMask = 1 << piedrasLayer;
        //int otrosMask = 1 << otrosLayer;

        filtroLayerMask = colisionMask | aguaMask | arbolesMask | piedrasMask;
    }

    
    void Update()
    {
        //El jugador se mueve al movepoint según la velocidad
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, vMovimiento * Time.deltaTime);
        posicion = transform.position;

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");


        animator.SetFloat("Horizontal", Mathf.Abs(horizontal));
        animator.SetFloat("Vertical", Mathf.Abs(vertical));


        //Para limitar el movimiento del movepoint, que solo se podrá volver a mover cuando el jugador esté a punto
        //de alcanzarlo, evitando movimiento infinito
        if (Vector3.Distance(transform.position, movePoint.position) <= 0.01f)
        {

            if (Mathf.Abs(horizontal) == 1 && Time.timeScale==1)
            {
                if (horizontal == 1)
                {
                    ultimaDireccion = "right";
                    transform.localScale = new Vector3(1,transform.localScale.y, transform.localScale.z);
                }
                else
                {
                    ultimaDireccion = "left";
                    transform.localScale = new Vector3(-1,transform.localScale.y, transform.localScale.z);
                }

                /*Antes de realizar el movimiento comprobamos que el punto al que nos queremos mover no es de colisión,
                Para ello dibujamos un círculo en el punto al que nos queremos desplazar y si está en la capa de colisiones no se 
                realiza el movimiento
                */
                if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(horizontal, 0f, 0f), .2f, filtroLayerMask))
                {

                //movemos el movepoint por si el botón está presionado
                movePoint.position += new Vector3(horizontal, 0f, 0f);

                }
            }
            if (Mathf.Abs(vertical) == 1 && Time.timeScale==1)
            {
                if (vertical == 1)
                {
                    ultimaDireccion = "up";
                }
                else
                {
                    ultimaDireccion = "down";
                }
                 if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, vertical, 0f), .2f, filtroLayerMask))
                {

                //movemos el movepoint por si el botón está presionado
                movePoint.position += new Vector3(0f, vertical, 0f);

                }

            }
        }
    }

    public static string GetUltimaDireccion()
    {
        return ultimaDireccion;
    }
    public static Vector2 GetPosicion()
    {
        return posicion;
    }
}
