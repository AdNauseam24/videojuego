using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Pez : MonoBehaviour
{
    [SerializeField]
    private Transform mp;

   // [SerializeField]
    //private float velocidad = 5f;

    //[SerializeField]
   // private float tiempoCambio;

    private Vector2 objetivoGiro;

    private Vector2 objetivoMovimiento;

    public float velocidad = 1f;

    public float tiempoCambio;

    void Start()
    {
        
    }
    void Update()
    {
        transform.up = objetivoGiro;
       // transform.position = objetivoMovimiento;
       transform.position += transform.up*velocidad*Time.unscaledDeltaTime;


       
        if(Time.realtimeSinceStartup >= tiempoCambio)
        {
            velocidad = Random.Range(4f, 8f);
            tiempoCambio = Time.realtimeSinceStartup + Random.Range(0f, 5f);

        }
        
    }

    public void ActivarPez()
    {
        tiempoCambio = Time.realtimeSinceStartup + Random.Range(0f, 5f);
    }

    public void Girar(Vector2 vector2)
    {
        Vector2 vector21 = vector2 - (Vector2)transform.position;
        StartCoroutine(LerpGiro(transform.up, vector21, 1f));
    }
    public void CambiarDireccion(Vector2 vector2)
    {
        StartCoroutine(LerpDireccion(transform.position, vector2, 1.5f));
    }
    IEnumerator LerpGiro(Vector2 start, Vector2 target, float lerpDuration)
    {
        float timeElapsed = 0f;
     
        while(timeElapsed < lerpDuration)
        {
           
            timeElapsed += Time.unscaledDeltaTime;
            objetivoGiro = Vector2.Lerp(start,target,timeElapsed/lerpDuration);
            yield return null;
        }
        StartCoroutine(LerpGiro(transform.up, mp.position-transform.position,0.5f));
    }
    IEnumerator LerpDireccion(Vector2 start, Vector2 target, float lerpDuration)
    {
        float timeElapsed = 0f;
        while(timeElapsed < lerpDuration)
        {
            timeElapsed += Time.unscaledDeltaTime;
            objetivoMovimiento= Vector2.Lerp(start,target,timeElapsed/lerpDuration);;
            yield return null;
        }
    }
    private void OnEnable()
    {
            MovePointPez.OnCambioPosicion += Girar;
            MovePointPez.OnCambioPosicion += CambiarDireccion;
    }
     private void OnDisable()
    {
            MovePointPez.OnCambioPosicion -= Girar;
            MovePointPez.OnCambioPosicion -= CambiarDireccion;

    }
}
