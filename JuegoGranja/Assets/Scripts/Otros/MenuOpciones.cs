using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuOpciones : MonoBehaviour
{
    public Image panelOpciones;
    public Image panelConfirmacion;

    private bool opcionesAbierto;

    private bool menuPrincipal;

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
            GameObject.FindGameObjectWithTag("Fade").GetComponent<CanvasGroup>().alpha = 0.5f;
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
        panelConfirmacion.gameObject.SetActive(true);
    }
    public void BotonConfirmar()
    {
        if (menuPrincipal)
        {
            SceneManager.LoadScene("MainMenu");
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
