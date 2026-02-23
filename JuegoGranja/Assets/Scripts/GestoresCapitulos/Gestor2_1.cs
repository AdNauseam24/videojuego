using System.Collections;
using TMPro;
using UnityEngine;

public class Gestor2_1 : MonoBehaviour
{
public GameObject jugador;
 public TMP_Text textoArriba;
 private CanvasGroup canvasTextoArriba;
 private Animator jugadorAnim;

 public GameObject ciclope;
 private Animator ciclopeAnim;

 public GameObject camara;



void OnEnable()
    {
        TriggerTexto.OnMandarTexto+=MostrarTexto;
    }
 void Start()
    {
        jugadorAnim = jugador.GetComponent<Animator>();
        ciclopeAnim = ciclope.GetComponent<Animator>();
        canvasTextoArriba = textoArriba.GetComponent<CanvasGroup>();
        StartCoroutine(Script1());
    }

    public IEnumerator Script1()
    {
        ciclopeAnim.Play("Idle_Ciclope");
        jugadorAnim.SetFloat("Horizontal",1);
        yield return new WaitForSeconds(1.5f);
        HerramientasEscenasScript.Instance.Fade(1,0,4f);
        HerramientasEscenasScript.Instance.MoverObjeto(jugador,new Vector3(-20.5f,0f,0), 5.5f);
        yield return new WaitForSeconds(5.5f);
        jugadorAnim.SetFloat("Horizontal",0);
        yield return new WaitForSeconds(1f);
        jugador.GetComponent<Movimiento>().enabled = true;
        HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasTextoArriba,textoArriba,"Por fin has llegado a las minas",4f);
        yield return new WaitForSeconds(4f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
             StartCoroutine(Script2());
        }
    }

    public IEnumerator Script2()
    {
       jugador.GetComponent<Movimiento>().enabled = false; 
       HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasTextoArriba,textoArriba,"Y no tardas mucho en encontrar a la criatura que te mencionaron",4f);
       yield return new WaitForSeconds(1f);
       HerramientasEscenasScript.Instance.MoverObjeto(camara,new Vector3(-20.5f,45,-10),5f);
       yield return new WaitForSeconds(6f);
       ciclopeAnim.Play("Movimiento_Ciclope");
       HerramientasEscenasScript.Instance.MoverObjeto(ciclope,new Vector3(-20,65,0),5);
       yield return new WaitForSeconds(2f);
       ciclope.SetActive(false);
       HerramientasEscenasScript.Instance.MoverObjeto(camara,new Vector3(jugador.transform.position.x, jugador.transform.position.y,-10),3f);
       yield return new WaitForSeconds(3.2f);
       StartCoroutine(camara.GetComponent<AgitarCamara>().Agitar(2.5f,1.5f));
       yield return new WaitForSeconds(3f);

       jugador.GetComponent<Movimiento>().enabled = true;
    }

    public void MostrarTexto(string txt)
    {
        HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasTextoArriba,textoArriba,txt,4);
    }

}
