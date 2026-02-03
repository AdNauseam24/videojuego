using UnityEngine;

public class Tendero : MonoBehaviour
{
    public Animator anim;
    private bool jugadorCerca;
    private bool tiendaabierta;

    public CanvasGroup canvasGroup;


    // Update is called once per frame
    void Update()
    {
        if (jugadorCerca)
        {
            if (Input.GetButtonDown("Interactuar"))
                {
                    if(!tiendaabierta)
                    {
                        Time.timeScale = 0;
                        tiendaabierta = true;
                        canvasGroup.alpha = 1;
                        canvasGroup.blocksRaycasts = true;
                        canvasGroup.interactable = true;
                        GestorInventario.Instance.DesactivarHotbar();
                    }
                    else
                    {
                        Time.timeScale = 1;
                        tiendaabierta = false;
                        canvasGroup.alpha = 0;
                        canvasGroup.blocksRaycasts = false;
                        canvasGroup.interactable = false;
                        GestorInventario.Instance.ActivarHotbar();
                    }
                }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.Play("Abrir");
            jugadorCerca=true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.Play("Cerrar");
            jugadorCerca=false;
        }
    }
}
