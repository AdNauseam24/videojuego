using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gestor3_2 : MonoBehaviour
{
   public Tuberia[] tuberias;
   public TMP_Text textoArriba;
   private CanvasGroup canvasTextoArriba;

    void OnEnable()
    {
        Tuberia.OnTuberiaGirada += ComprobarTuberias;
    }

    private void ComprobarTuberias()
    {
        foreach(Tuberia tuberia in tuberias)
        {
            if(!tuberia.activo)
                return;
        }
        DesactivarTuberias();
        StartCoroutine(Script2());
    }

    private void DesactivarTuberias()
    {
        foreach (Tuberia tuberia in tuberias)
        {
            tuberia.enabled = false;
        }
    }
    private void ActivarTuberias()
    {
        foreach (Tuberia tuberia in tuberias)
        {
            tuberia.enabled = true;
        }
    }

    void Start()
    {
        canvasTextoArriba = textoArriba.GetComponent<CanvasGroup>();
        StartCoroutine(Script1());
    }

    private IEnumerator Script1()
    {
        HerramientasEscenasScript.Instance.Fade(1,0,2f);
        yield return new WaitForSeconds(3f);

        HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasTextoArriba,textoArriba,"Verás, necesitamos conectar todas estas tuberías", 3f);
        yield return new WaitForSeconds(4f);

         HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasTextoArriba,textoArriba,"No llega suficiente agua para mantener toda la vida del bosque", 3f);
        yield return new WaitForSeconds(4f);

         HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasTextoArriba,textoArriba,"Así que te pedimos por favor que nos ayudes con ello", 3f);
        yield return new WaitForSeconds(4f);

        ActivarTuberias();
    }

    private IEnumerator Script2()
    {
        
        HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasTextoArriba,textoArriba,"¡Lo has conseguido!", 3f);
        yield return new WaitForSeconds(4f);

        
        HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasTextoArriba,textoArriba,"Pero todavía hay trabajo por hacer", 3f);
        yield return new WaitForSeconds(4f);

        
        HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasTextoArriba,textoArriba,"Sígueme y ayúdanos", 3f);
        yield return new WaitForSeconds(3.5f);

        HerramientasEscenasScript.Instance.Fade(0,1,2f);
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene("Capitulo3-3");

    }

}
