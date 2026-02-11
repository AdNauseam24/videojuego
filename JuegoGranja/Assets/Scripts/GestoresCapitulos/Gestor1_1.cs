using UnityEngine;
using System.Collections;
using TMPro;

public class Gestor1_1 : MonoBehaviour
{
    public Sprite[] jugadorSprite;
    public GameObject jugador;
    public Animator anim;

    public TMP_Text subtitulo;
    public TMP_Text textoArriba;
    public Camera camara;

    public GameObject troll;


    void Awake()
    {
        anim.SetBool("Tumbado", true);
    }
    void OnEnable()
    {
        StartCoroutine(Script());
        TriggerTexto.OnMandarTexto+=MostrarTexto;
    }

    public IEnumerator Script()
    {
        GameObject fadeimg = GameObject.FindGameObjectWithTag("Fade");
        fadeimg.GetComponent<CanvasGroup>().alpha =1;
        yield return new WaitForSeconds(1f);
        while (fadeimg.GetComponent<CanvasGroup>().alpha > 0)
        {
            fadeimg.GetComponent<CanvasGroup>().alpha -= 0.1f;
            yield return new WaitForSeconds(0.05f);
        }
         yield return new WaitForSeconds(0.5f);
          anim.SetBool("Levantarse", true);
         anim.SetBool("Tumbado", false);
         yield return new WaitForSeconds(1.5f);
         anim.SetBool("Levantarse", false);
         yield return new WaitForSeconds(0.2f);
         jugador.GetComponent<Movimiento>().enabled = true;
         subtitulo.text = "Utiliza WASD para moverte";
         subtitulo.GetComponent<CanvasGroup>().alpha = 1;
         yield return new WaitForSeconds(5);
        while(subtitulo.GetComponent<CanvasGroup>().alpha > 0)
        {
            subtitulo.GetComponent<CanvasGroup>().alpha -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
         
    }

    public IEnumerator Espera(int segundos)
    {
        yield return new WaitForSeconds(segundos);
    }

    public void MostrarTexto(string txt)
    {
        StopAllCoroutines();
        textoArriba.GetComponent<CanvasGroup>().alpha = 0;
        subtitulo.GetComponent<CanvasGroup>().alpha = 0;
        StartCoroutine(TextoEnPantalla(txt));
    }
    public IEnumerator TextoEnPantalla(string txt)
    {
        textoArriba.text = txt;
        textoArriba.GetComponent<CanvasGroup>().alpha = 1;
         yield return new WaitForSeconds(5);
         while(textoArriba.GetComponent<CanvasGroup>().alpha > 0)
        {
            textoArriba.GetComponent<CanvasGroup>().alpha -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
             jugador.GetComponent<Movimiento>().enabled = false;
             anim.Play("Idle");
             StartCoroutine(MovimientoCamara());
             StartCoroutine(Script2());
             troll.GetComponent<Animator>().Play("Troll_Atacar");

             
        }
    }

    public IEnumerator MovimientoCamara()
    {
        float timeElapsed = 0f;
        float lerpDuration = 3f;
        Vector3 posicionInicial = camara.transform.position;
        Vector3 posicionObjetivo = new Vector3(posicionInicial.x+20,posicionInicial.y,posicionInicial.z);

         while(timeElapsed < lerpDuration)
        {
            timeElapsed += Time.unscaledDeltaTime;
            camara.transform.position = Vector3.Lerp(posicionInicial,posicionObjetivo, timeElapsed/lerpDuration);
            yield return null;
        }
        yield return new WaitForSeconds(3f);

        timeElapsed = 0f;
        lerpDuration = 3f;
        posicionInicial = camara.transform.position;
        posicionObjetivo = new Vector3(posicionInicial.x-20,posicionInicial.y,posicionInicial.z);
        while(timeElapsed < lerpDuration)
        {
            timeElapsed += Time.unscaledDeltaTime;
            camara.transform.position = Vector3.Lerp(posicionInicial,posicionObjetivo, timeElapsed/lerpDuration);
            yield return null;
        }
        

    }

    public IEnumerator Script2()
    {
        textoArriba.text = "Ves a una criatura enfermiza en la distancia";
        textoArriba.GetComponent<CanvasGroup>().alpha = 1;
         yield return new WaitForSeconds(2.5f);

        textoArriba.text = "Parece que está atacando a alguien";
        textoArriba.GetComponent<CanvasGroup>().alpha = 1;
         yield return new WaitForSeconds(2);
        troll.GetComponent<Animator>().Play("New State");
        troll.transform.localScale = new Vector3(-2,2,1);
         yield return new WaitForSeconds(1.5f);
        textoArriba.text = "Parece que te ha visto";
        textoArriba.GetComponent<CanvasGroup>().alpha = 1;
         troll.GetComponent<Animator>().Play("Troll_Caminar");
       

        float timeElapsed = 0f;
        float lerpDuration = 3f;
        Vector3 posicionInicial = troll.transform.position;
        Vector3 posicionObjetivo = new Vector3(posicionInicial.x-25,posicionInicial.y,posicionInicial.z);

         while(timeElapsed < lerpDuration)
        {
            timeElapsed += Time.unscaledDeltaTime;
            troll.transform.position = Vector3.Lerp(posicionInicial,posicionObjetivo, timeElapsed/lerpDuration);
            yield return null;
        }

        GameObject fadeimg = GameObject.FindGameObjectWithTag("Fade");
        
        timeElapsed = 0f;
        lerpDuration = 0.5f;
         while(timeElapsed < lerpDuration)
        {
            timeElapsed += Time.unscaledDeltaTime;
            fadeimg.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(0,1,timeElapsed/lerpDuration);
           
            yield return null;
        }

    }

    
}
