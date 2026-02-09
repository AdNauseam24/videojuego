using System.Collections;
using UnityEngine;

public class GestorPueblo1 : MonoBehaviour
{
    void OnEnable()
    {
        StartCoroutine(OcultarFade());
        GestorTenderos.Instance.ActivarTenderosPueblo1();
    }

    void OnDisable()
    {
        GestorTenderos.Instance.DesactivarTenderosPueblo1();
    }

    public IEnumerator OcultarFade()
    {
        GameObject fadeimg = GameObject.FindGameObjectWithTag("Fade");
        fadeimg.GetComponent<CanvasGroup>().alpha =1;
        yield return new WaitForSeconds(0.25f);
        while (fadeimg.GetComponent<CanvasGroup>().alpha > 0)
        {
            fadeimg.GetComponent<CanvasGroup>().alpha -= 0.1f;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
