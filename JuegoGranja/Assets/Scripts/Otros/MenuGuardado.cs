using System.Collections;
using TMPro;
using UnityEngine;

public class MenuGuardado : MonoBehaviour
{
    public Canvas canvas;
    public TMP_Text textoDia;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canvas.gameObject.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canvas.gameObject.SetActive(false);
        }
    }

    public void CerrarMenu()
    {
        canvas.gameObject.SetActive(false);
    }

    public void GuardarPartida()
    {
        StatsGenerales.Instance.dia++;
        Guardado.Save();
        CerrarMenu();
        Time.timeScale = 0;
        StartCoroutine(CambioDia());

    }
    public IEnumerator CambioDia()
    {
        DialogueHistoryTracker.Instance.CambioDia();
        StatsGenerales.Instance.ReestablecerEnergia();
        GameObject fadeimg = GameObject.FindGameObjectWithTag("Fade");
        
        float timeElapsed = 0f;
        float  lerpDuration = 2f;
        while(timeElapsed < lerpDuration)
        {
            timeElapsed += Time.unscaledDeltaTime;
            fadeimg.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(0,1,timeElapsed/lerpDuration);
           
            yield return null;
        }

        textoDia.text = "Día " + StatsGenerales.Instance.dia;
        textoDia.enabled = true;
        yield return new WaitForSecondsRealtime(3f);

        textoDia.enabled = false;

        timeElapsed = 0f;
        lerpDuration = 2f;
        while(timeElapsed < lerpDuration)
        {
            timeElapsed += Time.unscaledDeltaTime;
            fadeimg.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(1,0,timeElapsed/lerpDuration);
           
            yield return null;
        }
        Time.timeScale = 1;


    }
}
