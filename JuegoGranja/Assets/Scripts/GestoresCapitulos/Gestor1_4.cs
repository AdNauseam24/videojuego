using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gestor1_4 : MonoBehaviour
{
public TMP_Text textoArriba;
private CanvasGroup canvasTextoArriba;
public SpriteRenderer spriteJugador;
public Sprite jugadorDespierto;

public DialogoSO dialogoVampiros;
public DialogoSO dialogoHumanos;

public SpriteRenderer[] spriteRenderers;

public Sprite[] spritesHumanos;

public Animator exclamacion;

private bool dialogosActivos;

    void OnEnable()
    {
        ComportamientoDerivadoPrueba.OnDialogoTerminado += EmpezarScrip2;
    }
    void OnDisable()
    {
        ComportamientoDerivadoPrueba.OnDialogoTerminado -= EmpezarScrip2;
    }
    void Start()
    {
        if(RegistroAyuda.Instance.ayuda == 1)
        {
            for (int i = 0; i < 3; i++)
            {
                spriteRenderers[i].sprite = spritesHumanos[i]; 
            }
        }
        canvasTextoArriba = textoArriba.GetComponent<CanvasGroup>();
        StartCoroutine(Script1());
    }
    void Update()
    {
        if(dialogosActivos && Input.GetButtonDown("Interactuar") && GestorDIalogos.Instance.dialogoActivo)
        {
             GestorDIalogos.Instance.AvanzarDialogo(null);
        }
    }

    public IEnumerator Script1()
    {
        yield return new WaitForSeconds(2f);

        HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasTextoArriba, textoArriba, "Oyes un cuchicheo", 3f);
        yield return new WaitForSeconds(4.5f);

        HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasTextoArriba, textoArriba, "No sabes dónde estás, pero sientes que te encuentras sobre una superficie mullida", 3f);
        yield return new WaitForSeconds(4.5f);

        HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasTextoArriba, textoArriba, "Decides abrir los ojos", 3f);
        yield return new WaitForSeconds(1.5f);

        HerramientasEscenasScript.Instance.Fade(1,0,3.5f);
        yield return new WaitForSeconds(4f);

        spriteJugador.sprite = jugadorDespierto;

        yield return new WaitForSeconds(2f);

        exclamacion.Play("Exclamacion");

        yield return new WaitForSeconds(2.5f);

        dialogosActivos = true;

        if(RegistroAyuda.Instance.ayuda == 2)
        {
            GestorDIalogos.Instance.EmpezarDialogo(dialogoVampiros);
        }
        else
        {
             GestorDIalogos.Instance.EmpezarDialogo(dialogoHumanos);
        }

    }

    public void EmpezarScrip2()
    {
        dialogosActivos = false;
        StartCoroutine(Script2());
    }

    public IEnumerator Script2()
    {
         HerramientasEscenasScript.Instance.Fade(0,1,1f);
        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i < 3; i++)
            {
                spriteRenderers[i].enabled = false;
            }
         HerramientasEscenasScript.Instance.Fade(1,0,1f);
        yield return new WaitForSeconds(1f);
         HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasTextoArriba, textoArriba, "Parece que se han marchado", 3f);
        yield return new WaitForSeconds(4.5f);
        HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasTextoArriba, textoArriba, "Quizás lo mejor es dormir un rato más y luego ver qué haces...", 3f);
        yield return new WaitForSeconds(4.5f);
        HerramientasEscenasScript.Instance.Fade(0,1,3f);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("SampleScene");


    }

}
