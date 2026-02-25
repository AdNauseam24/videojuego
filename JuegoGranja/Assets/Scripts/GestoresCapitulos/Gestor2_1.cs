using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gestor2_1 : MonoBehaviour
{
public GameObject jugador;
 public TMP_Text textoArriba;
 private CanvasGroup canvasTextoArriba;
 private Animator jugadorAnim;

 public GameObject ciclope;
 private Animator ciclopeAnim;

 public GameObject camara;

 public Animator pocion;
 public Animator exclamacion;
 public GameObject pocionGO;
 public Animator ciclope2;



void OnEnable()
    {
        TriggerTexto.OnMandarTexto+=MostrarTexto;
        Trigger2_1.OnEmpezarScript+= EmpezarScript3;
    }
 void Start()
    {
        Jugador.Instance.gameObject.SetActive(false);
        GestorInventario.Instance.gameObject.SetActive(false);
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

    public void EmpezarScript3()
    {
        StartCoroutine(Script3());
    }

    public IEnumerator Script3()
    {
        jugador.GetComponent<Movimiento>().enabled = false;
        HerramientasEscenasScript.Instance.MoverObjeto(jugador, new Vector3(-25.5f,147.5f,0),2);
        jugadorAnim.SetFloat("Horizontal",1);
        HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasTextoArriba,textoArriba,"¡Lo has alcanzado!",3);
        yield return new WaitForSeconds(2f);
        
        jugadorAnim.SetFloat("Horizontal",0);
        yield return new WaitForSeconds(2f);   

        HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasTextoArriba,textoArriba,"Es hora de usar la poción que te dieron",3);
        yield return new WaitForSeconds(1.5f);

        pocionGO.GetComponent<SpriteRenderer>().enabled = true;
        pocion.Play("LanzamientoPocion");
        yield return new WaitForSeconds(0.9f);

        Destroy(pocionGO);
        yield return new WaitForSeconds(1f);

        exclamacion.Play("Exclamacion");
        yield return new WaitForSeconds(1.5f);

        ciclope2.Play("Caer_Ciclope");
        yield return new WaitForSeconds(1f);

        HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasTextoArriba,textoArriba,"¡Ha funcionado!",3);
        yield return new WaitForSeconds(4f);

        HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasTextoArriba,textoArriba,"Pero en ese momento...",3);
        yield return new WaitForSeconds(4f);

        HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasTextoArriba,textoArriba,"Vuelves a escuchar el mismo rugido de la primera vez",3);
        yield return new WaitForSeconds(4f);
        
        StartCoroutine(camara.GetComponent<AgitarCamara>().Agitar(2.5f,1.5f));
        HerramientasEscenasScript.Instance.Fade(0,1,2f);
        yield return new WaitForSeconds(2.5f);

        HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasTextoArriba,textoArriba,"Y otra vez pierdes la consciencia",3);
        yield return new WaitForSeconds(6f);

         Jugador.Instance.gameObject.SetActive(true);
        GestorInventario.Instance.gameObject.SetActive(true);

        StatsGenerales.Instance.capituloHistoria = 1;
        StatsGenerales.Instance.entregado = false;
        DialogueHistoryTracker.Instance.LImpiarLista();

        SceneManager.LoadScene("SampleScene");



    }

}
