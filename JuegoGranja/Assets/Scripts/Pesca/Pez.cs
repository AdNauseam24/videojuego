using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Pez : MonoBehaviour
{
    [SerializeField]
    private Transform mp;

    [SerializeField]
    private MovePointPez movePointPez;

    [SerializeField]
    private float velocidad = 5f;

    [SerializeField]
    private float tiempoCambio;

    [SerializeField]
    private Vector2 objetivoGiro;

    [SerializeField]
    private Vector2 objetivoMovimiento;
    void Start()
    {
        
    }
    void Update()
    {
        transform.up = objetivoGiro;
        //transform.position = Vector2.MoveTowards(transform.position, mp.position,  Time.unscaledDeltaTime*velocidad);
        transform.position = objetivoMovimiento;

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
        float x;
        float y;

        while(timeElapsed < lerpDuration)
        {
            x = Mathf.Lerp(start.x, target.x,timeElapsed/lerpDuration);
            y = Mathf.Lerp(start.y, target.y, timeElapsed/lerpDuration);
            timeElapsed += Time.unscaledDeltaTime;
            objetivoGiro= new Vector2(x,y);
            yield return null;
        }
    }
    IEnumerator LerpDireccion(Vector2 start, Vector2 target, float lerpDuration)
    {
        float timeElapsed = 0f;
        float x;
        float y;

        while(timeElapsed < lerpDuration)
        {
            x = Mathf.Lerp(start.x, target.x,timeElapsed/lerpDuration);
            y = Mathf.Lerp(start.y, target.y, timeElapsed/lerpDuration);
            timeElapsed += Time.unscaledDeltaTime;
            objetivoMovimiento= new Vector2(x,y);
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
