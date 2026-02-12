using System.Collections;
using TMPro;
using UnityEngine;

public class Gestor1_4 : MonoBehaviour
{
public TMP_Text textoArriba;
private CanvasGroup canvasTextoArriba;
public SpriteRenderer spriteJugador;
public Sprite jugadorDespierto;

public SpriteRenderer[] spriteRenderers;

public Sprite[] spritesHumanos;

public Animator exclamacion;

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

    }

}
