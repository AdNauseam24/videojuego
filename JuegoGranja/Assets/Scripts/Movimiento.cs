using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float vMovimiento = 5f;

   //El punto al que queremos que el jugador se desplace en cada movimiento, 
   // con el fin de que siempre esté en los márgenes de una celda
    public Transform movePoint;
    
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

        if (Vector3.Distance(transform.position, movePoint.position) <= 0.1f)
        {

            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1)
            {
                //movemos el movepoint por si el botón está presionado
                movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
            }
            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1)
            {
                //movemos el movepoint por si el botón está presionado
                movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
            }
        }
    }
}
