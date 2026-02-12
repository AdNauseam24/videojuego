using System.Collections;
using TMPro;
using UnityEngine;

public class Gestor1_3 : MonoBehaviour
{
 public GameObject jugador;
 public TMP_Text textoArriba;
 private CanvasGroup canvasTextoArriba;
 private Animator jugadorAnim;

 public CanvasGroup botones;
 private bool botonesActivos;

 public Camera camera;



    void Start()
    {
        jugadorAnim = jugador.GetComponent<Animator>();
        canvasTextoArriba = textoArriba.GetComponent<CanvasGroup>();
        StartCoroutine(Script1());
    }

    public IEnumerator Script1()
    {
         HerramientasEscenasScript.Instance.Animar(jugadorAnim,"Idle2");
        
        HerramientasEscenasScript.Instance.Fade(1,0,0.1f);
        yield return new WaitForSeconds(0.5f);

        HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasTextoArriba,textoArriba,"¡Has Vencido!", 3f);
        yield return new WaitForSeconds(4.5f);
        HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasTextoArriba,textoArriba,"Te das cuenta de que bajo la capa tenías otra cosa... \n¡Una Poción!", 3f);
        yield return new WaitForSeconds(4.5f);
        HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasTextoArriba,textoArriba,"Entonces te acuerdas de que eres un alquimista, pero solo tienes una poción...", 3f);
         yield return new WaitForSeconds(4.5f);
        HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasTextoArriba,textoArriba,"Solo vas a poder ayudar a una de las personas", 3f);
        HerramientasEscenasScript.Instance.Fade(0,0.5f,1f);
        yield return new WaitForSeconds(0.5f);
        HerramientasEscenasScript.Instance.MostrarYOcultarCanvasGroup(botones,0,1,0.5f);
        botonesActivos = true;
        

    }

    public void clickIzda()
    {
        if (botonesActivos)
        {
            RegistroAyuda.Instance.ayuda = 1;
            botonesActivos = false;
            HerramientasEscenasScript.Instance.MostrarYOcultarCanvasGroup(botones,1,0,0.5f);
            HerramientasEscenasScript.Instance.Animar(jugadorAnim,"Movimiento2");
            jugador.transform.localScale = new Vector3(-1,1,0);
            HerramientasEscenasScript.Instance.MoverObjeto(jugador, new Vector3(-4.5f,7,0),2.5f);
            StartCoroutine(Agitar());
        }
    }
    public void clickDcha()
    {
         if (botonesActivos)
        {
            RegistroAyuda.Instance.ayuda = 2;
            botonesActivos = false;
            HerramientasEscenasScript.Instance.MostrarYOcultarCanvasGroup(botones,1,0,0.5f);
            HerramientasEscenasScript.Instance.Animar(jugadorAnim,"Movimiento2");
            HerramientasEscenasScript.Instance.MoverObjeto(jugador, new Vector3(4.5f,7,0),2.5f);
            StartCoroutine(Agitar());
        }
    }

    public IEnumerator Agitar()
    {
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(camera.GetComponent<AgitarCamara>().Agitar(3.5f,1f));
        yield return new WaitForSeconds(1.55f);
        HerramientasEscenasScript.Instance.Fade(0,1,1.75f);
        yield return new WaitForSeconds(1.75f);
        HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasTextoArriba,textoArriba,"Después de oír un rugido ensordecedor, la cueva colapsa y pierdes la conciencia", 5f);
    }


}
