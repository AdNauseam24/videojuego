using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gestor3_4 : MonoBehaviour
{
   public Tierra[] tierra;
   public Transform abuela;
   public TMP_Text textoArriba;
   private CanvasGroup canvasArriba;

   public DialogoSO[] dialogos;

   public Animator juagdorAnim;
   private bool dialogosActivos;

   void OnEnable()
    {
        ComportamientoDerivadoPrueba.OnDialogoTerminado += EmpezarScript2;
    }
     void OnDisable()
    {
        ComportamientoDerivadoPrueba.OnDialogoTerminado -= EmpezarScript2;
    }

    void Start()
    {
        canvasArriba = textoArriba.GetComponent<CanvasGroup>();
        StartCoroutine(Script1());
    }

    private IEnumerator Script1()
    {
        HerramientasEscenasScript.Instance.Fade(1,0,3f);
        yield return new WaitForSeconds(5f);

        int contador = 0;
        List<int> encontrados = new List<int>();

        while(contador < tierra.Length)
        {
            int n = Random.Range(0,tierra.Length);

            if (encontrados.Contains(n))
            {
                continue;
            }
            else
            {
                encontrados.Add(n);
                contador++;
                tierra[n].GetComponent<SpriteRenderer>().sprite = tierra[n].sprites[0];
            }
            yield return new WaitForSeconds(0.1f);
        }
        encontrados.Clear();
        contador = 0;

        while(contador < tierra.Length)
        {
            int n = Random.Range(0,tierra.Length);

            if (encontrados.Contains(n))
            {
                continue;
            }
            else
            {
                encontrados.Add(n);
                contador++;
                tierra[n].GetComponent<SpriteRenderer>().sprite = tierra[n].sprites[1];
            }
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(1f);
        abuela.localScale = new Vector3(-abuela.localScale.x, abuela.localScale.y, abuela.localScale.z);

        yield return new WaitForSeconds(1f);

        dialogosActivos = true;
        GestorDIalogos.Instance.EmpezarDialogo(dialogos[0]);


    }

    public void EmpezarScript2()
    {
        dialogosActivos = false;
        StartCoroutine(Script2());
    }
    private IEnumerator Script2()
    {
        yield return new WaitForSeconds(2f);
        juagdorAnim.SetBool("caer", true);

        yield return new WaitForSeconds(3f);
        HerramientasEscenasScript.Instance.Fade(0,1,5f);
        yield return new WaitForSeconds(4f);

        HerramientasEscenasScript.Instance.MostrarYOcultarTexto(canvasArriba,textoArriba,"Y así concluye tu extraño encuentro en el bosque", 4);
        yield return new WaitForSeconds(6f);

        Jugador.Instance.gameObject.SetActive(true);
        GestorInventario.Instance.gameObject.SetActive(true);

        StatsGenerales.Instance.capituloHistoria = 2;
        StatsGenerales.Instance.entregado = false;
        DialogueHistoryTracker.Instance.LImpiarLista();

        SceneManager.LoadScene("SampleScene");




    }

     void Update()
    {
         if(dialogosActivos && Input.GetButtonDown("Interactuar") && GestorDIalogos.Instance.dialogoActivo)
        {
             GestorDIalogos.Instance.AvanzarDialogo(null);
        }
    }

   
}
