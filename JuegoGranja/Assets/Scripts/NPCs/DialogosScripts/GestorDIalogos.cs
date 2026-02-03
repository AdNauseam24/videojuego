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
    public void AvanzarDialogo()
    {
        if(indiceDialogo < dialogoActual.lineas.Length)
        {
            MostrarDialogo();
        }
        else
        {
            MostrarOpciones();
        }
    }
    private void MostrarDialogo()
    {
        LineaDialogo linea = dialogoActual.lineas[indiceDialogo];

        DialogueHistoryTracker.Instance.RegistrarNPC(linea.speaker);

        retrato.sprite = linea.speaker.retrato;
        nombreActor.text = linea.speaker.nombreActor;
        textoDialogo.text = linea.texto;

        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;

        indiceDialogo++;
    }

    private void MostrarOpciones()
    {
        LimpiarOpciones();
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

    private void TerminarDialogo()
    {
        indiceDialogo = 0;
        dialogoActivo = false;
        LimpiarOpciones();

        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
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
}
