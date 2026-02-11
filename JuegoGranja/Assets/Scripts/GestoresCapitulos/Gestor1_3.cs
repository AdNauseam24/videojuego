using System.Collections;
using TMPro;
using UnityEngine;

public class Gestor1_3 : MonoBehaviour
{
 public GameObject jugador;
 public TMP_Text textoArriba;
 private CanvasGroup canvasTextoArriba;
 private Animator jugadorAnim;

    void Start()
    {
        jugadorAnim = jugador.GetComponent<Animator>();
        canvasTextoArriba = textoArriba.GetComponent<CanvasGroup>();
        StartCoroutine(Script1());
    }

    public IEnumerator Script1()
    {
        
        HerramientasEscenasScript.Instance.Fade(1,0,0.1f);
        yield return new WaitForSeconds(0.5f);

        StartCoroutine(HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasTextoArriba,textoArriba,"¡Has Vencido!", 3f));
        yield return new WaitForSeconds(4.5f);
        StartCoroutine(HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasTextoArriba,textoArriba,"Te das cuenta de que bajo la capa tenías otra cosa... \n¡Una Poción!", 3f));
        yield return new WaitForSeconds(4.5f);
        StartCoroutine(HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasTextoArriba,textoArriba,"Entonces te acuerdas de que eres un alquimista, pero solo tienes una poción...", 3f));
         yield return new WaitForSeconds(4.5f);
        StartCoroutine(HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasTextoArriba,textoArriba,"Solo vas a poder ayudar a una de las personas", 3f));
        yield return null;
        HerramientasEscenasScript.Instance.Animar(jugadorAnim,"movimientoJugador");

    }


}
