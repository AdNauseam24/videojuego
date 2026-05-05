using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
public class Gestor1_2 : MonoBehaviour
{
    public Animator animTroll;
    private bool listoParaEmpezar;
    public TMP_Text textoArriba;
    public TMP_Text textoPuntuacion;
    public TMP_Text textoMultiplicador;
    public BeatScroller beatScroller;
    public AudioSource musica;

    public GameObject laud;
    private Animator laudAnimator;
    private bool reproducir;
    private int puntuacion;
    public int puntuacionPorNota = 100;
    public CanvasGroup textoDerrota;

    public Transform jugador;
    public GameObject troll;
    public Sprite trollDormido;

    private bool disponibleReempezar;

    public Canvas textosPuntuaciones;
    public GameObject flechas;
    public GameObject botones;

    private int multiplicador = 1;
    private int multTracker = 0;
    public int[] umbrales;

    public static Gestor1_2 Instance;

    void Awake()
    {
        Instance = this;
    }


    void OnEnable()
    {
        laudAnimator = laud.GetComponent<Animator>();
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
            textoArriba.GetComponent<CanvasGroup>().alpha = 0f;
            beatScroller.empezado = true;
            musica.Play();
        }
        if(musica.time> 60 && reproducir)
        {
            botones.SetActive(false);
            reproducir = false;
            musica.Stop();
            if(puntuacion > 10000)
            {
                StartCoroutine(Script6());
            }
            else
            {
                StartCoroutine(Script3());
            }
        }

        if(disponibleReempezar && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Script4());
        }
    }
    public IEnumerator Script6()
    {
        yield return new WaitForSeconds(2.5f);
        animTroll.Play("New State");

        AudioManager.Instance.PlaySFX(AudioManager.Instance.caida);

        troll.GetComponent<SpriteRenderer>().sprite = trollDormido;
        yield return new WaitForSeconds(0.5f);

        AudioManager.Instance.PlaySFX(AudioManager.Instance.monstruoDormido);

        yield return new WaitForSeconds(3f);
        StartCoroutine(Script5());

    }
    public IEnumerator Script4()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Capitulo1-2");
    }
    public IEnumerator Script3()
    {
        animTroll.Play("Troll_Caminar");
        float timeElapsed = 0f;
        float lerpDuration = 0.75f;
        Vector3 posicionInicial = troll.transform.position;
        Vector3 objetivo = jugador.position;
        StartCoroutine(Script5());
       
         while(timeElapsed < lerpDuration)
        {
            timeElapsed += Time.unscaledDeltaTime;
           troll.transform.position = Vector3.Lerp(posicionInicial,objetivo,timeElapsed/lerpDuration);
           
            yield return null;
        }
       
        yield return new WaitForSeconds(1.5f);

        timeElapsed = 0f;
        lerpDuration = 2.5f;
        while(timeElapsed < lerpDuration)
        {
            timeElapsed += Time.unscaledDeltaTime;
            textoDerrota.alpha = Mathf.Lerp(0,1,timeElapsed/lerpDuration);
           
            yield return null;
        }
        disponibleReempezar = true;
    }

    public IEnumerator Script5()
    {
        yield return new WaitForSeconds(0.25f);
        GameObject fadeimg = GameObject.FindGameObjectWithTag("Fade");
        
        float timeElapsed = 0f;
        float  lerpDuration = 0.6f;
        while(timeElapsed < lerpDuration)
        {
            timeElapsed += Time.unscaledDeltaTime;
            fadeimg.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(0,1,timeElapsed/lerpDuration);
           
            yield return null;
        }
        if(puntuacion > 10000)
        {
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene("Capitulo1-3");
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
        AudioManager.Instance.PlaySFX(AudioManager.Instance.rugidoMonstruo2);
        yield return new WaitForSeconds(3.5f);

        textoArriba.text = "La criatura te corta el paso y no tienes por donde huir";
        yield return new WaitForSeconds(3.5f);

        textoArriba.text = "Entonces te das cuenta de que llevas algo encima...";
        //AudioManager.Instance.StopMusic();
        yield return new WaitForSeconds(3.5f);

        textoArriba.text = "¡Tienes un laud!";
        AudioManager.Instance.PlaySFX(AudioManager.Instance.treasureFound, 0.2f);
        yield return new WaitForSeconds(0.5f);

        laud.SetActive(true);
        laudAnimator.Play("laud");
        yield return new WaitForSeconds(3f);

        textoArriba.text = "Quizás con eso puedas calmarlo...";
        laud.GetComponent<SpriteRenderer>().sortingOrder = 100;
        laudAnimator.Play("New State");
        laudAnimator.enabled = false;
        laud.transform.localPosition = new Vector3(-21.42f,-3.97f,0);
        AudioManager.Instance.PlaySFX(AudioManager.Instance.rugidoMonstruo1);
        yield return new WaitForSeconds(3.5f);

        textoArriba.text = "Pulsa espacio cuando estés listo para empezar";
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
