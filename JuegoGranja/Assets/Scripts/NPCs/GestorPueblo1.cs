using System.Collections;
using UnityEngine;

public class GestorPueblo1 : MonoBehaviour
{
    public GameObject roca;
    public GameObject[] puentes;
    public GameObject[] vallas;


    void OnEnable()
    {
        StartCoroutine(OcultarFade());
        GestorTenderos.Instance.ActivarTenderosPueblo1();
        
        if (StatsGenerales.Instance.puentePueblo1)
        {
            roca.SetActive(false);
            foreach (var puente in puentes)
            {
                puente.SetActive(true);
            }
        }
        
        if (StatsGenerales.Instance.vallaPueblo1)
        {
            
            foreach (var valla in vallas)
            {
                valla.SetActive(false);
            }
        }
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
