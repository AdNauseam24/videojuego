using UnityEngine;
using System.Collections;
using Unity.Android.Gradle;

public class GestorGranja : MonoBehaviour
{
    public GameObject[] arboles;
     public GameObject[] rocas;
     void OnEnable()
    {
        StartCoroutine(OcultarFade());
        for (int i = 0; i < 2; i++)
        {
            if (StatsGenerales.Instance.arbolesTalados[i])
            {
                Destroy(arboles[i]);
            }
             if (StatsGenerales.Instance.rocasPicadas[i])
            {
                Destroy(rocas[i]);
            }
        }

       
    }
    void Start()
    {
         if(RegistroAyuda.Instance != null)
        {
            if(RegistroAyuda.Instance.ayuda == 1)
            {
                StatsGenerales.Instance.afinidadPueblo1 ++;
                StatsGenerales.Instance.ultimaAfinidad = 1;
            }
            else
            {
                StatsGenerales.Instance.afinidadPueblo2++;
                 StatsGenerales.Instance.ultimaAfinidad = 2;
            }
            Destroy(RegistroAyuda.Instance.gameObject);
        }
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
