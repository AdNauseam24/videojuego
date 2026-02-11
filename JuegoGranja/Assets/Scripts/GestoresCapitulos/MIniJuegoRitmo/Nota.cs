using UnityEngine;

public class Nota : MonoBehaviour
{
  
  public bool pulsable;
  public KeyCode key;

  private bool pulsada;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            if (pulsable)
            {
                pulsada = true;
                gameObject.SetActive(false);
                Gestor1_2.Instance.noteHit();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Activador"))
        {
            pulsable = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Activador"))
        {
            pulsable = false;
            if (!pulsada)
            {
                 Gestor1_2.Instance.noteMissed();
            }
           
        }
    }
}
