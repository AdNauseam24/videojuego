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
             StartCoroutine(Script2());
        }
    }

    public IEnumerator Script2()
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

    }
}
