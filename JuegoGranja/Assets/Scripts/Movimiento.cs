using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float vMovimiento = 5f;

   //El punto al que queremos que el jugador se desplace en cada movimiento, 
   // con el fin de que siempre esté en los márgenes de una celda
    public Transform movePoint;

    //La capa con la cual va a colisionar nuestro personaje
    public LayerMask colisionar;
    
    void Start()
    {
        //para que se mueva el movepoint y el jugador lo siga, si no al moverse pj se movería movepoint
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        //El jugador se mueve al movepoint según la velocidad
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, vMovimiento * Time.deltaTime);

        //Para limitar el movimiento del movepoint, que solo se podrá volver a mover cuando el jugador esté a punto
        //de alcanzarlo, evitando movimiento infinito
        if (Vector3.Distance(transform.position, movePoint.position) <= 0.01f)
        {

            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1 && Time.timeScale==1)
            {
                /*Antes de realizar el movimeinto comprobamos que el punto al que nos queremos mover no es de colisión,
                Para ello dibujamos un círculo en el punto al que nos queremos desplazar y si está en la capa de colisiones no se 
                realiza el movimiento
                */
                if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, colisionar))
                {

                //movemos el movepoint por si el botón está presionado
                movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);

                }
            }
            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1 && Time.timeScale==1)
            {
                 if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, colisionar))
                {

                //movemos el movepoint por si el botón está presionado
                movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);

                }

            }
        }
    }
}
