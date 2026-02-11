using UnityEngine;
using System.Collections;
using TMPro;

public class Gestor1_2 : MonoBehaviour
{
    public Animator animTroll;
    public bool listoParaEmpezar;
    public bool minijuegoActivo;
    public TMP_Text textoArriba;
    public TMP_Text textoPuntuacion;
    public TMP_Text textoMultiplicador;
    public BeatScroller beatScroller;
    public AudioSource musica;
    public bool reproducir;
    public int puntuacion;
    public int puntuacionPorNota = 100;

    public Canvas textosPuntuaciones;
    public GameObject flechas;
    public GameObject botones;

    public int multiplicador = 1;
    public int multTracker = 0;
    public int[] umbrales;

    public static Gestor1_2 Instance;

    void Awake()
    {
        Instance = this;
    }


    void OnEnable()
    {
        animTroll.Play("Troll_Idle");
        StartCoroutine(Script());
    }

    void Update()
    {
        if(listoParaEmpezar && Input.GetKeyDown(KeyCode.Space))
        {
            textosPuntuaciones.gameObject.SetActive(true);
            flechas.SetActive(true);
            botones.SetActive(true);
            listoParaEmpezar = false;
            reproducir = true;
            minijuegoActivo = true;
            textoArriba.GetComponent<CanvasGroup>().alpha = 0f;
            beatScroller.empezado = true;
            musica.Play();
        }
        if(musica.time> 60)
        {
            musica.Stop();
        }
    }

    public IEnumerator Script()
    {
         GameObject fadeimg = GameObject.FindGameObjectWithTag("Fade");
        
        float timeElapsed = 0f;
        float lerpDuration = 0.75f;
         while(timeElapsed < lerpDuration)
        {
            timeElapsed += Time.unscaledDeltaTime;
            fadeimg.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(1,0,timeElapsed/lerpDuration);
           
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        textoArriba.GetComponent<CanvasGroup>().alpha = 1f;
        textoArriba.text = "No sabes qué hacer para escapar";
        yield return new WaitForSeconds(2.5f);
         textoArriba.text = "La criatura te corta el paso y no tienes por donde huir";
        yield return new WaitForSeconds(2.5f);
         textoArriba.text = "Entonces te das cuenta de que llevas algo encima...";
        yield return new WaitForSeconds(2.5f);
         textoArriba.text = "¡Tienes un laud!";
        yield return new WaitForSeconds(2.5f);
         textoArriba.text = "Quizás con eso puedas calmarlo...";
        yield return new WaitForSeconds(2.5f);
         textoArriba.text = "Pulsa espacio cuando estes listo para empezar";
        listoParaEmpezar = true;
    }

    public void noteHit()
    {
        Debug.Log("Hit");

        if(multiplicador-1 < umbrales.Length){
        multTracker ++;

        if(umbrales[multiplicador-1] <= multTracker)
        {
            multTracker = 0;
            multiplicador++;
            textoMultiplicador.text = "x" + multiplicador;
        }
        }
        puntuacion += puntuacionPorNota * multiplicador;
        textoPuntuacion.text = puntuacion.ToString();
    }
    public void noteMissed()
    {
        Debug.Log("miss");
        multTracker = 0;
        multiplicador = 1;
        textoMultiplicador.text = "x" + multiplicador;
    }
}
