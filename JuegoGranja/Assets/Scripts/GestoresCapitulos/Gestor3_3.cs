using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gestor3_3 : MonoBehaviour
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
        StartCoroutine(Script1());
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
        ActivarTuberias();
        HerramientasEscenasScript.Instance.Fade(1,0,3f);
    }

    private IEnumerator Script1()
    {
        HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasTextoArriba,textoArriba,"¡Increíble!", 3f);
        yield return new WaitForSeconds(3f);
        HerramientasEscenasScript.Instance.Fade(0,1,4f);
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene("Capitulo3-4");

    }

}
