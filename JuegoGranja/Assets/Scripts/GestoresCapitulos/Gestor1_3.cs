using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gestor1_3 : MonoBehaviour
{
 public GameObject jugador;
 public TMP_Text textoArriba;

 public GameObject pocion;
 private Animator animatorPocion;
 private CanvasGroup canvasTextoArriba;
 private Animator jugadorAnim;

 public CanvasGroup botones;
 private bool botonesActivos;

 public new Camera camera;



    void Start()
    {
        jugadorAnim = jugador.GetComponent<Animator>();
        animatorPocion = pocion.GetComponent<Animator>();
        canvasTextoArriba = textoArriba.GetComponent<CanvasGroup>();
        StartCoroutine(Script1());
    }

    public IEnumerator Script1()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.monstruoDormido, 0.1f);

        HerramientasEscenasScript.Instance.Animar(jugadorAnim,"Idle2");
        
        HerramientasEscenasScript.Instance.Fade(1,0,0.1f);
        yield return new WaitForSeconds(0.5f);

        HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasTextoArriba,textoArriba,"¡Has Vencido!", 4f);
        yield return new WaitForSeconds(5.5f);

        HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasTextoArriba,textoArriba,"Te das cuenta de que bajo la capa tenías otra cosa... \n¡Una Poción!", 4f);
        animatorPocion.Play("pocionRoja");
        AudioManager.Instance.PlaySFX(AudioManager.Instance.treasureFound,0.2f);
        yield return new WaitForSeconds(3.5f);
        animatorPocion.Play("New State");
        animatorPocion.enabled = false;
        pocion.GetComponent<SpriteRenderer>().sortingOrder = 100;
        pocion.transform.rotation = Quaternion.Euler(0,0,-30);
        pocion.transform.localPosition = new Vector3(0.24f,0.28f,0);
        yield return new WaitForSeconds(2f);

        HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasTextoArriba,textoArriba,"Entonces te acuerdas de que eres un alquimista, pero solo tienes una poción...", 4f);
        yield return new WaitForSeconds(5.5f);

        HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasTextoArriba,textoArriba,"Solo vas a poder ayudar a una de las personas", 4f);
        yield return new WaitForSeconds(1.5f);

        HerramientasEscenasScript.Instance.Fade(0,0.5f,1f);
        yield return new WaitForSeconds(1f);

        HerramientasEscenasScript.Instance.MostrarYOcultarCanvasGroup(botones,0,1,0.5f);
        botonesActivos = true;
        

    }

    public void clickIzda()
    {
        if (botonesActivos)
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.clickMenu);
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
            AudioManager.Instance.PlaySFX(AudioManager.Instance.clickMenu);
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
        yield return new WaitForSeconds(0.5f);

        AudioManager.Instance.PlaySFX(AudioManager.Instance.rugidoLegendario, 2);

        yield return new WaitForSeconds(1.5f);

        StartCoroutine(camera.GetComponent<AgitarCamara>().Agitar(3.5f,1f));

        AudioManager.Instance.PlaySFX(AudioManager.Instance.derrumbe);

        yield return new WaitForSeconds(1f);

        HerramientasEscenasScript.Instance.Animar(jugadorAnim,"Idle2");

        HerramientasEscenasScript.Instance.Fade(0,1,2.75f);
        yield return new WaitForSeconds(4.75f);
        HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasTextoArriba,textoArriba,"Después de oír un rugido ensordecedor, la cueva colapsa y pierdes la conciencia", 5f);
        yield return new WaitForSeconds(5f);
        AudioManager.Instance.ChangeMusicVolume(0f);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Capitulo1-4");
    }


}
