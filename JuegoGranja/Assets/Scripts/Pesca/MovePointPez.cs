using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class MovePointPez : MonoBehaviour
{

    [SerializeField]
    private float radio;

    [SerializeField]
    private float tiempoCambio;

    [SerializeField]
    private Vector2 centro;
    

    
    void Update()
    {
        if(Time.realtimeSinceStartup >= tiempoCambio)
        {
            float r = radio * Mathf.Sqrt(Random.Range(0f,1f));
            float theta = Random.Range(0f,1f) * 2 * Mathf.PI;

            float x = centro.x + r * Mathf.Cos(theta);
            float y = centro.y + r * Mathf.Sin(theta);

            transform.position = new Vector2(x,y);
            tiempoCambio = Time.realtimeSinceStartup + Random.Range(2f,3f);
        }
    }

    public void SetRadio(float f)
    {
        this.radio = f;
        
    }
    public void Empezar()
    {
         float r = radio * Mathf.Sqrt(Random.Range(0f,1f));
            float theta = Random.Range(0f,1f) * 2 * Mathf.PI;

            float x = centro.x + r * Mathf.Cos(theta);
            float y = centro.y + r * Mathf.Sin(theta);

            transform.position = new Vector2(x,y);
        tiempoCambio = Time.realtimeSinceStartup + Random.Range(2f,3f);
    }
    public void SetCentro(Vector2 posicion)
    {
        this.centro = posicion;
    }

    public Vector2 GetPosition()
    {
        return transform.position;
    }
     void OnTriggerEnter2D(Collider2D collision)
    {
         if(collision.gameObject.tag == "Pez")
        {
            float r = radio * Mathf.Sqrt(Random.Range(0f,1f));
            float theta = Random.Range(0f,1f) * 2 * Mathf.PI;

            float x = centro.x + r * Mathf.Cos(theta);
            float y = centro.y + r * Mathf.Sin(theta);

            transform.position = new Vector2(x,y);
            tiempoCambio = Time.realtimeSinceStartup + Random.Range(2f,3f);
        }
    }
}
