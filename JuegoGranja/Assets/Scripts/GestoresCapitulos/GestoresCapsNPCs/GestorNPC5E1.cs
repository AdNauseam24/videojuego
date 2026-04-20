using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestorNPC5E1 : MonoBehaviour
{
    public GameObject jugador;
    
    private Animator jugadorAnim;
    public GameObject camara;
    public GameObject NPC;
    public Sprite[] spritesNPC;
    public DialogoSO[] dialogos;
    private int contador = 0;
    private bool dialogosActivos;

    void OnEnable()
    {
        ComportamientoDerivadoPrueba.OnDialogoTerminado += EmpezarScript2;
    }

     void OnDisable()
    {
        ComportamientoDerivadoPrueba.OnDialogoTerminado -= EmpezarScript2;
    }
     private void EmpezarScript2()
    {
        dialogosActivos = false;
        if(contador == 0)
        {
            contador++;
           StartCoroutine(Script2());
        }
        else
        {
            StartCoroutine(Script3());
        }
    }

     void Start()
    {
        Jugador.Instance.gameObject.SetActive(false);
        GestorInventario.Instance.gameObject.SetActive(false);
        jugadorAnim = jugador.GetComponent<Animator>();
        StartCoroutine(Script1());
    }

    private IEnumerator Script1()
    {
        jugadorAnim.SetFloat("Horizontal",1);
        yield return new WaitForSeconds(1.5f);

        HerramientasEscenasScript.Instance.Fade(1,0,2f);
        HerramientasEscenasScript.Instance.MoverObjeto(jugador,new Vector3(-49f,48f,0), 7f);
        yield return new WaitForSeconds(6.7f);

         jugadorAnim.SetFloat("Horizontal",0);

        yield return new WaitForSeconds(1.5f);

        NPC.GetComponent<SpriteRenderer>().sprite = spritesNPC[0];

        yield return new WaitForSeconds(1);
         dialogosActivos = true;
        GestorDIalogos.Instance.EmpezarDialogo(dialogos[0]);
    }

    private IEnumerator Script2()
    {
        yield return new WaitForSeconds(1f);
        NPC.GetComponent<SpriteRenderer>().sprite = spritesNPC[1];
        yield return new WaitForSeconds(1f);
         dialogosActivos = true;
        GestorDIalogos.Instance.EmpezarDialogo(dialogos[1]);
    }

    private IEnumerator Script3()
    {
        yield return new WaitForSeconds(0.5f);
        HerramientasEscenasScript.Instance.Fade(0,1,5f);
        yield return new WaitForSeconds(5f);
        Jugador.Instance.gameObject.SetActive(true);
        GestorInventario.Instance.gameObject.SetActive(true);
        DialogueHistoryTracker.Instance.escenasPendientes.Remove("NPC5P1Escena1");
        DialogueHistoryTracker.Instance.personajesRelacionables[0].nivelRelacion = 20;
        SceneManager.LoadScene("Pueblo1");
    }

    void Update()
    {
         if(dialogosActivos && Input.GetButtonDown("Interactuar") && GestorDIalogos.Instance.dialogoActivo)
        {
             GestorDIalogos.Instance.AvanzarDialogo(null);
        }
    }



}
