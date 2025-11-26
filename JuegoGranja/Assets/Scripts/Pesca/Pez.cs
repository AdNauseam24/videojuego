using UnityEngine;

public class Pez : MonoBehaviour
{
    [SerializeField]
    private Transform mp;

    [SerializeField]
    private float velocidad = 5f;

    [SerializeField]
    private float tiempoCambio;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, mp.position,  Time.unscaledDeltaTime*velocidad);

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
}
