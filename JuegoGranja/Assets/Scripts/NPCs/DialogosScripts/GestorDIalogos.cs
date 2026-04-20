using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GestorDIalogos : MonoBehaviour
{
    public static GestorDIalogos Instance;

    [Header("Referencias UI")]
    public Image retrato;
    public TMP_Text nombreActor;
    public TMP_Text textoDialogo;
    public CanvasGroup canvasGroup;
    public Button[] botonesOpciones;

    public Image[] corazones;

    private DialogoSO dialogoActual;
    private int indiceDialogo;
    public bool dialogoActivo;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        OcultarCorazones();

        foreach (Button boton in botonesOpciones)
        {
            boton.gameObject.SetActive(false);
        }
    }
    public void EmpezarDialogo(DialogoSO dialogoSO)
    {
        dialogoActual = dialogoSO;
        indiceDialogo = 0;
        dialogoActivo = true;
        MostrarDialogo();
    }
    public void AvanzarDialogo(System.Action accionPosterior)
    {
        if(indiceDialogo < dialogoActual.lineas.Length)
        {
            MostrarDialogo();
        }
        else
        {
            MostrarOpciones(accionPosterior);
        }
    }
    private void MostrarDialogo()
    {
        LineaDialogo linea = dialogoActual.lineas[indiceDialogo];

        DialogueHistoryTracker.Instance.RegistrarNPC(linea.speaker);
        if (!linea.speaker.habladoHoy && linea.speaker.aplicable)
        {
            linea.speaker.habladoHoy = true;
            linea.speaker.nivelRelacion +=1;

        }

        if( linea.speaker.nivelRelacion >= 10 && linea.speaker.nivelRelacion < 20)
        {
            DialogueHistoryTracker.Instance.escenasPendientes.Add(linea.speaker.escenaNivel1);
        }
        if( linea.speaker.nivelRelacion >= 30 && linea.speaker.nivelRelacion < 40)
        {
            DialogueHistoryTracker.Instance.escenasPendientes.Add(linea.speaker.escenaNivel2);
        }
        if( linea.speaker.nivelRelacion >= 50 && linea.speaker.nivelRelacion < 60)
        {
            DialogueHistoryTracker.Instance.escenasPendientes.Add(linea.speaker.escenaNivel3);
        }
        
        retrato.sprite = linea.speaker.retrato;
        nombreActor.text = linea.speaker.nombreActor;
        textoDialogo.text = linea.texto;

        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;

        MostrarCorazones();

        indiceDialogo++;
    }

    private void MostrarOpciones(System.Action accionPosterior)
    {
        if(dialogoActual.accion != null)
        {
            dialogoActual.accion.OnUse();
        }
        else
        {
            LimpiarOpciones();
            if(accionPosterior != null)
            {
                TerminarDialogo();
                accionPosterior();
                return;
            }
            
            if(dialogoActual.opciones.Length > 0)
            {
                for (int i = 0; i < dialogoActual.opciones.Length; i++)
                {
                    var opcion = dialogoActual.opciones[i];

                    botonesOpciones[i].GetComponentInChildren<TMP_Text>().text = opcion.textoOpcion;
                    botonesOpciones[i].gameObject.SetActive(true);

                    botonesOpciones[i].onClick.AddListener(() => ElegirOpcion(opcion.nextDialogo));
                }
            }
            else
            {
                botonesOpciones[0].GetComponentInChildren<TMP_Text>().text = "Salir";
                botonesOpciones[0].gameObject.SetActive(true);
                botonesOpciones[0].onClick.AddListener(TerminarDialogo);
            }
        }
       

    }

    public void TerminarDialogoScripted()
    {
        indiceDialogo = 0;
        dialogoActivo = false;
        LimpiarOpciones();

        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        OcultarCorazones();
        Time.timeScale = 1;
    }
    public void TerminarDialogo()
    {
        indiceDialogo = 0;
        dialogoActivo = false;
        LimpiarOpciones();

        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        OcultarCorazones();
        GestorInventario.Instance.ActivarHotbar();
        Time.timeScale = 1;
    }

    private void ElegirOpcion(DialogoSO dialogoSO)
    {
        if(dialogoSO == null)
        {
            TerminarDialogo();
        }
        else
        {
            LimpiarOpciones();
            EmpezarDialogo(dialogoSO);
        }
    }

    private void LimpiarOpciones()
    {
        foreach (var boton in botonesOpciones)
        {
            boton.gameObject.SetActive(false);
            boton.onClick.RemoveAllListeners();
        }
    }
    public void MostrarCorazones()
    {
        int n = dialogoActual.lineas[0].speaker.nivelRelacion/10;
        if(n>6)
            n=6;
        
        for (int i = 0; i < n; i++)
        {
            corazones[i].GetComponent<CanvasGroup>().alpha = 1;
        }
    }
    public void OcultarCorazones()
    {
        foreach (var corazon in corazones)
        {
            corazon.GetComponent<CanvasGroup>().alpha = 0;
        }
    }
    public static void Prueba()
    {
        
    }
}
