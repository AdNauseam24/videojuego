using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gestor4_1 : MonoBehaviour
{
    public GameObject jugador;
    public TMP_Text textoArriba;
    private CanvasGroup canvasTextoArriba;
    private Animator jugadorAnim;
    public Camera camara;
    private Animator exclamacionAnim;
    public GameObject exclamacion;

    //cabeza, cuerpo 1,2,3 y cola   
    public GameObject[] serpiente;

    private Animator[] cuerpoAnim = new Animator[3];

    void Start()
    {
        jugadorAnim = jugador.GetComponent<Animator>();
        canvasTextoArriba = textoArriba.GetComponent<CanvasGroup>();
        exclamacionAnim = exclamacion.GetComponent<Animator>();

        for (int i = 0; i < 3; i++)
        {
            cuerpoAnim[i] = serpiente[i+1].GetComponent<Animator>();
        }

        StartCoroutine(Script1());
    }

    private IEnumerator Script1()
    {
        HerramientasEscenasScript.Instance.Fade(1,0,3f);

        jugadorAnim.SetFloat("Horizontal",1);

        HerramientasEscenasScript.Instance.MoverObjeto(jugador,new Vector3(0,-30,0),6f);
        yield return new WaitForSeconds(2f);

        HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasTextoArriba,textoArriba,"Por fin estás en la playa, así que toca ponerse a explorar...",3f);
        yield return new WaitForSeconds(3f);
        jugadorAnim.SetFloat("Horizontal",0);
        yield return new WaitForSeconds(0.5f);

        jugadorAnim.SetFloat("Horizontal",0);

        exclamacionAnim.Play("Exclamacion");
        yield return new WaitForSeconds(0.5f);

        HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasTextoArriba,textoArriba,"¡Pero qué!",2f);

        HerramientasEscenasScript.Instance.AlejarCamara(camara,30,10f);

        

        yield return new WaitForSeconds(9f);

        HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasTextoArriba,textoArriba,"¡Es la criatura más grande que hayas visto jamás!",3f);

        yield return new WaitForSeconds(2f);

        jugadorAnim.SetFloat("Horizontal",1);
        HerramientasEscenasScript.Instance.MoverObjeto(jugador,new Vector3(0,-43,0),6f);
        yield return new WaitForSeconds(2f);

         HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasTextoArriba,textoArriba,"Decides acercate a ver qué pasa...",3f);
         HerramientasEscenasScript.Instance.AlejarCamara(camara,15,6f);

         yield return new WaitForSeconds(3.5f);
          jugadorAnim.SetFloat("Horizontal",0);

         yield return new WaitForSeconds(2.5f);

         StartCoroutine(camara.GetComponent<AgitarCamara>().Agitar(3.5f,3));
         yield return new WaitForSeconds(4.5f);

        HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasTextoArriba,textoArriba,"La criatura suelta un rugido que parece hacer temblar el mundo",3f);
        yield return new WaitForSeconds(4f);

        HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasTextoArriba,textoArriba,"Sin embargo no parece tener intenciones hostiles",3f);
        yield return new WaitForSeconds(4f);

         StartCoroutine(camara.GetComponent<AgitarCamara>().Agitar(1.5f,1.5f));
         yield return new WaitForSeconds(1.5f);

        HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasTextoArriba,textoArriba,"De hecho parece que quiere que la sigas",3f);
        yield return new WaitForSeconds(4f);

        foreach (var anim in cuerpoAnim)
        {
            anim.Play("Cuerpo_Serpiente");
        }

        HerramientasEscenasScript.Instance.MoverObjeto(serpiente[0], new Vector3(serpiente[0].transform.position.x, serpiente[0].transform.position.y-6, 0),1f);
        yield return new WaitForSeconds(1.1f);

        for (int i = 1; i < serpiente.Length; i++)
        {
            serpiente[i].transform.position = new Vector3(serpiente[i].transform.position.x+6, serpiente[i].transform.position.y, 0);
        }
        yield return new WaitForSeconds(0.4f);

        Destroy(serpiente[1]);

        for (int i = 2; i < serpiente.Length; i++)
        {
            serpiente[i].transform.position = new Vector3(serpiente[i].transform.position.x+6, serpiente[i].transform.position.y, 0);
        }
        yield return new WaitForSeconds(0.4f);

        Destroy(serpiente[2]);

        for (int i = 3; i < serpiente.Length; i++)
        {
            serpiente[i].transform.position = new Vector3(serpiente[i].transform.position.x+6, serpiente[i].transform.position.y, 0);
        }
        yield return new WaitForSeconds(0.4f);

        Destroy(serpiente[3]);

         for (int i = 4; i < serpiente.Length; i++)
        {
            serpiente[i].transform.position = new Vector3(serpiente[i].transform.position.x+6, serpiente[i].transform.position.y, 0);
        }
        yield return new WaitForSeconds(0.4f);

        Destroy(serpiente[4]);

        yield return new WaitForSeconds(1f);

         HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasTextoArriba,textoArriba,"Bueno, habrá que probar",3f);
        yield return new WaitForSeconds(3f);

        jugadorAnim.SetFloat("Horizontal",1);

        HerramientasEscenasScript.Instance.MoverObjeto(jugador,new Vector3(0,-70,0),40f);

        yield return new WaitForSeconds(0.6f);

        HerramientasEscenasScript.Instance.Fade(0,1,2f);

        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Capitulo4_2");





    }

}
