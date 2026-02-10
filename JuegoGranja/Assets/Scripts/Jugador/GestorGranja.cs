using UnityEngine;
using System.Collections;

public class GestorGranja : MonoBehaviour
{
    public GameObject[] arboles;
     void OnEnable()
    {
        StartCoroutine(OcultarFade());
        for (int i = 0; i < 2; i++)
        {
            if (StatsGenerales.Instance.arbolesTalados[i])
            {
                Destroy(arboles[i]);
            }
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
