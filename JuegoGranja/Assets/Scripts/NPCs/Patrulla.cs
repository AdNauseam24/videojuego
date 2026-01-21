using System.Collections;
using UnityEngine;

public class Patrulla : MonoBehaviour
{

    public Vector2[] puntosMovimiento;
    public Vector2 objetivo;
  
    public float velocidad;
    private Rigidbody2D rb;
    private bool pausado;
    private int objetivoActual;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        objetivo = puntosMovimiento[objetivoActual];
    }

    // Update is called once per frame
    void Update()
    {
        if (pausado)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        Vector2 direction = ((Vector3)objetivo - transform.position).normalized;
        rb.linearVelocity = direction * velocidad;

        if(Vector2.Distance(transform.position,objetivo) < .1f)
        {
            StartCoroutine(SetPuntoObjetivo());
        }
    }

    IEnumerator SetPuntoObjetivo()
    {
        pausado = true;

        yield return new WaitForSeconds(Random.Range(2,10));
        objetivoActual = Random.Range(0,puntosMovimiento.Length);
        objetivo = puntosMovimiento[objetivoActual];
        pausado = false;
    }
}
