using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gestor4_2 : MonoBehaviour
{
    public GameObject jugador;
    public TMP_Text textoArriba;
    private CanvasGroup canvasTextoArriba;
    private Animator jugadorAnim;

    public Camera camara;

    void Start()
    {
        jugadorAnim = jugador.GetComponent<Animator>();
        canvasTextoArriba = textoArriba.GetComponent<CanvasGroup>();

        StartCoroutine(Script1());
    }

    private IEnumerator Script1()
    {
        HerramientasEscenasScript.Instance.Fade(1,0,3f);
        yield return new WaitForSeconds(2f);

        HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasTextoArriba,textoArriba,"De alguna forma parece que eres capaz de respirar en el fondo marino",3f);
        yield return new WaitForSeconds(1.5f);

        jugadorAnim.SetFloat("Horizontal",1);
        HerramientasEscenasScript.Instance.MoverObjeto(jugador,new Vector3(-8,-13,0),6f);
        yield return new WaitForSeconds(5.5f);
        jugadorAnim.SetFloat("Horizontal",0);

        HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasTextoArriba,textoArriba,"La criatura parece completamente desesperada por ayuda",3f);
        yield return new WaitForSeconds(2.5f);

         StartCoroutine(camara.GetComponent<AgitarCamara>().Agitar(1.5f,1.5f));
         yield return new WaitForSeconds(1.5f);

          HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasTextoArriba,textoArriba,"Pues nada, habrá que ayudarla a ver si deja de causar problemas",3f);
        yield return new WaitForSeconds(2.5f);

         HerramientasEscenasScript.Instance.Fade(0,1,3f);
        yield return new WaitForSeconds(6f);

        SceneManager.LoadScene("Capitulo4-3");





    }
}
