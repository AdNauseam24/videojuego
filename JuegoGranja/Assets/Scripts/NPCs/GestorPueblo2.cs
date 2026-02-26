using UnityEngine;
using System.Collections;

public class GestorPueblo2 : MonoBehaviour
{
    public GameObject roca;
    public GameObject[] puentes;
    public GameObject[] vallas;
       void OnEnable()
    {
        StartCoroutine(OcultarFade());
        GestorTenderos.Instance.ActivarTenderosPueblo2();

        if (StatsGenerales.Instance.PuentePueblo2)
        {
            roca.SetActive(false);
            foreach (var puente in puentes)
            {
                puente.SetActive(true);
            }
        }
          if (StatsGenerales.Instance.vallaPueblo2)
        {
            
            foreach (var valla in vallas)
            {
                valla.SetActive(false);
            }
        }
    }

    void OnDisable()
    {
        GestorTenderos.Instance.DesactivarTenderosPueblo2();
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
