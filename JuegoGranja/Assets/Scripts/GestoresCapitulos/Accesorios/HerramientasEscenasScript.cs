using UnityEngine;
using System.Collections;
using TMPro;

public class HerramientasEscenasScript : MonoBehaviour
{
    public static HerramientasEscenasScript Instance;

    void Awake()
    {
        Instance = this;
    }

    public void Fade(float inicial, float final, float tiempo)
    {
        StartCoroutine(FadeCoroutine(inicial,final,tiempo));
    }
    private IEnumerator FadeCoroutine(float inicial, float final, float tiempo)
    {
        GameObject fadeimg = GameObject.FindGameObjectWithTag("Fade");
        
        float timeElapsed = 0f;
        float  lerpDuration = tiempo;
        while(timeElapsed < lerpDuration)
        {
            timeElapsed += Time.unscaledDeltaTime;
            fadeimg.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(inicial,final,timeElapsed/lerpDuration);
           
            yield return null;
        }
    }

    public void MoverObjeto(GameObject objeto, Vector3 final, float tiempo)
    {
        StartCoroutine(MoverObjetoCoroutine(objeto,final,tiempo));
    }
    private IEnumerator MoverObjetoCoroutine(GameObject objeto, Vector3 final, float tiempo)
    {
        float timeElapsed = 0f;
        float lerpDuration = tiempo;
        Vector3 posicionInicial = objeto.transform.position;
        Vector3 objetivo = final;

         while(timeElapsed < lerpDuration)
        {
            timeElapsed += Time.unscaledDeltaTime;
           objeto.transform.position = Vector3.Lerp(posicionInicial,objetivo,timeElapsed/lerpDuration);
           
            yield return null;
        }
    }

    public void Animar(Animator anim, string nombre)
    {
        anim.Play(nombre);
    }

    public void MostrarYOcultarTexto(CanvasGroup canvas, TMP_Text texto,string str, float tiempo)
    {
        StartCoroutine(MostrarYOcultarTextoCoroutine(canvas,texto,str,tiempo));
    }
    private IEnumerator MostrarYOcultarTextoCoroutine(CanvasGroup canvas, TMP_Text texto,string str, float tiempo)
    {
        canvas.alpha = 1f;
        texto.text = str;
        float timeElapsed = 0f;
        float lerpDuration = 1f;
        yield return new WaitForSeconds(tiempo);
        while(timeElapsed < lerpDuration)
        {
            timeElapsed += Time.unscaledDeltaTime;
            canvas.alpha = Mathf.Lerp(1,0,timeElapsed/lerpDuration);
           
            yield return null;
        }

    }

     public void MostrarYOcultarCanvasGroup(CanvasGroup canvas,float inicial, float final, float tiempo)
    {
        StartCoroutine(MostrarYOcultarCanvasGroupCoroutine(canvas,inicial,final,tiempo));
    }
    private IEnumerator MostrarYOcultarCanvasGroupCoroutine(CanvasGroup canvas,float inicial, float final, float tiempo)
    {
        canvas.alpha = inicial;
        float timeElapsed = 0f;
        float lerpDuration = tiempo;
        while(timeElapsed < lerpDuration)
        {
            timeElapsed += Time.unscaledDeltaTime;
            canvas.alpha = Mathf.Lerp(inicial,final,timeElapsed/lerpDuration);
           
            yield return null;
        }

    }
}
