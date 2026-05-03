using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuOpciones : MonoBehaviour
{
    public Image panelOpciones;
    public Image panelConfirmacion;

    public Slider sliderGeneral;
    public Slider sliderMusica;
    public Slider sliderSFX;

    public TMP_Text textoGeneral;
    public TMP_Text textoMusica;
    public TMP_Text textoSFX;

    private bool opcionesAbierto;

    private bool menuPrincipal;

    void Start()
    {
        UpdateUI();
        panelOpciones.gameObject.SetActive(false);
        panelConfirmacion.gameObject.SetActive(false);

    }

    public void BotonOpciones()
    {
         if(Time.timeScale == 1 && !opcionesAbierto)
        {
            AbrirOpciones();
        }
        else if(Time.timeScale == 0 && opcionesAbierto)
        {
            CerrarOpciones();
        }
    }
    public void AbrirOpciones()
    {
        if(Time.timeScale == 1 && !opcionesAbierto)
        {
            Time.timeScale = 0;
            GameObject.FindGameObjectWithTag("Fade").GetComponent<CanvasGroup>().alpha = 0.8f;
            panelOpciones.gameObject.SetActive(true);
            opcionesAbierto = true;
        }
    }
    public void CerrarOpciones()
    {
        if(Time.timeScale == 0 && opcionesAbierto)
        {
            Time.timeScale = 1;
            GameObject.FindGameObjectWithTag("Fade").GetComponent<CanvasGroup>().alpha = 0f;
            panelOpciones.gameObject.SetActive(false);
            panelConfirmacion.gameObject.SetActive(false);
            opcionesAbierto = false;
        }
    }
    public void MenuPrincipal()
    {
        menuPrincipal = true;
        AbrirConfirmar();
    }
    public void Escritorio()
    {
        menuPrincipal = false;
        AbrirConfirmar();
    }
    private void AbrirConfirmar()
    {
        panelConfirmacion.gameObject.SetActive(true);
    }
    public void CerrarConfirmar()
    {
        panelConfirmacion.gameObject.SetActive(false);
    }
    public void BotonConfirmar()
    {
        if (menuPrincipal)
        {
           StartCoroutine(DelayFade());
        }
        else
        {
            #if UNITY_STANDALONE
            Application.Quit();
            #endif
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }
    }

    IEnumerator DelayFade()
    {
        GameObject.FindGameObjectWithTag("Fade").GetComponentInParent<Canvas>().sortingOrder = 101;

        GameObject fadeimg = GameObject.FindGameObjectWithTag("Fade");
        fadeimg.GetComponent<CanvasGroup>().blocksRaycasts = true;
        while(fadeimg.GetComponent<CanvasGroup>().alpha < 1)
        {
            fadeimg.GetComponent<CanvasGroup>().alpha += 0.05f;
            yield return new WaitForSecondsRealtime(0.05f);
        }
        yield return new WaitForSecondsRealtime(0.25f);

        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
        GameManager.Instance.Borrado();
        
    }

    private void UpdateUI()
    {
        sliderGeneral.value = StatsGenerales.Instance.volumenGeneral;
        sliderMusica.value = StatsGenerales.Instance.volumenMusica;
        sliderSFX.value = StatsGenerales.Instance.volumenSFX;

        textoGeneral.text = sliderGeneral.value == 0 ? "0" : (sliderGeneral.value*100).ToString("#");
        textoMusica.text = sliderMusica.value == 0 ? "0" :  (sliderMusica.value*100).ToString("#");
        textoSFX.text = sliderSFX.value == 0 ? "0" :  (sliderSFX.value*100).ToString("#");

        AudioManager.Instance.ChangeMusicVolume();
    }

    public void ChangeGeneral()
    {
        StatsGenerales.Instance.volumenGeneral = sliderGeneral.value;
        UpdateUI();
    }

    public void ChangeMusica()
    {
        StatsGenerales.Instance.volumenMusica = sliderMusica.value;
        UpdateUI();
    }

    public void ChangeSFX()
    {
        StatsGenerales.Instance.volumenSFX = sliderSFX.value;
        UpdateUI();
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1 && !opcionesAbierto)
        {
            AbrirOpciones();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0 && opcionesAbierto)
        {
            CerrarOpciones();
        }
    }
}
