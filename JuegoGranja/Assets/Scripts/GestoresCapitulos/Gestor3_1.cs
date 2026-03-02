using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Gestor3_1 : MonoBehaviour
{
public GameObject jugador;
public TMP_Text textoArriba;
private CanvasGroup canvasTextoArriba;
private Animator jugadorAnim;
public GameObject camara;
public GameObject loboGris;
public GameObject loboMarron;
public Sprite[] spritesLoboGris;
public Sprite[] spritesLoboMarron;

public DialogoSO[] dialogos;

public CanvasGroup brilloBlanco;

private Animator loboMarronAnim;

private int contador = 0;
private bool dialogosActivos;

//Jugador, lobo gris, lobo marrón
public Animator[] exclamaciones;

 void OnEnable()
    {
        ComportamientoDerivadoPrueba.OnDialogoTerminado += EmpezarScrip2;
    }

    private void EmpezarScrip2()
    {
        dialogosActivos = false;
        if(contador == 0)
        {
            contador++;
            StartCoroutine(Script2());
        }
    }

    void OnDisable()
    {
        ComportamientoDerivadoPrueba.OnDialogoTerminado -= EmpezarScrip2;
    }
    void Start()
    {
        //Jugador.Instance.gameObject.SetActive(false);
        //GestorInventario.Instance.gameObject.SetActive(false);
        jugadorAnim = jugador.GetComponent<Animator>();
        loboMarronAnim = loboMarron.GetComponent<Animator>();
        loboMarronAnim.enabled = false;
        canvasTextoArriba = textoArriba.GetComponent<CanvasGroup>();
        StartCoroutine(Script1());
    }

    private IEnumerator Script1()
    {
        jugadorAnim.SetFloat("Horizontal",1);
        yield return new WaitForSeconds(1.5f);

        HerramientasEscenasScript.Instance.Fade(1,0,3f);
        HerramientasEscenasScript.Instance.MoverObjeto(jugador,new Vector3(0f,-30f,0), 15f);
        yield return new WaitForSeconds(2f);

        HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasTextoArriba,textoArriba,"Llegas cerca de la arboleda",3f);
        yield return new WaitForSeconds(4f);

         HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasTextoArriba,textoArriba,"De primeras no escuchas nada, pero sigues avanzando hasta llegar a un claro",3f);
        yield return new WaitForSeconds(9f);

        jugadorAnim.SetFloat("Horizontal",0);

        HerramientasEscenasScript.Instance.MoverObjeto(camara,new Vector3(jugador.transform.position.x, jugador.transform.position.y-8,-10),3f);
        HerramientasEscenasScript.Instance.AlejarCamara(camara.GetComponent<Camera>(),11,3f);
        yield return new WaitForSeconds(3.5f);

        loboGris.GetComponent<SpriteRenderer>().sprite = spritesLoboGris[0];
        yield return new WaitForSeconds(1.5f);

        loboMarron.GetComponent<SpriteRenderer>().sprite = spritesLoboMarron[0];
        yield return new WaitForSeconds(2f);

        loboGris.GetComponent<SpriteRenderer>().sprite = spritesLoboGris[1];
        loboMarron.GetComponent<SpriteRenderer>().sprite = spritesLoboMarron[1];
        yield return new WaitForSeconds(1.5f);

        foreach(Animator exclamacion in exclamaciones)
        {
             exclamacion.Play("Exclamacion");
        }

        yield return new WaitForSeconds(1.5f);
        exclamaciones[0].Play("New State");

        loboGris.GetComponent<SpriteRenderer>().sprite = spritesLoboGris[2];
        loboMarron.GetComponent<SpriteRenderer>().sprite = spritesLoboMarron[2];
        yield return new WaitForSeconds(1.5f);

        loboMarronAnim.enabled = true;
        loboMarronAnim.Play("LoboMarron_Correr1");

        HerramientasEscenasScript.Instance.MoverObjeto(loboMarron,new Vector3(0f,-32f,0), 1.7f);
        yield return new WaitForSeconds(1.7f);

        loboMarronAnim.enabled = false;
        dialogosActivos = true;
        GestorDIalogos.Instance.EmpezarDialogo(dialogos[0]);
    
    }

    private IEnumerator Script2()
    {
        yield return new WaitForSeconds(1.5f);

        HerramientasEscenasScript.Instance.MostrarYOcultarCanvasGroup(brilloBlanco,0,1,1.5f);
        yield return new WaitForSeconds(2.5f);

        loboGris.GetComponent<SpriteRenderer>().sprite = spritesLoboGris[3];
        HerramientasEscenasScript.Instance.MostrarYOcultarCanvasGroup(brilloBlanco,1,0,1.5f);
        yield return new WaitForSeconds(2f);
        exclamaciones[0].Play("Exclamacion");
    }

    
    void Update()
    {
         if(dialogosActivos && Input.GetButtonDown("Interactuar") && GestorDIalogos.Instance.dialogoActivo)
        {
             GestorDIalogos.Instance.AvanzarDialogo(null);
        }
    }
}
