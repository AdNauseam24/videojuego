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
            TerminarDialogo();
        }
    }
    private void MostrarDialogo()
    {
        LineaDialogo linea = dialogoActual.lineas[indiceDialogo];

        retrato.sprite = linea.speaker.retrato;
        nombreActor.text = linea.speaker.nombreActor;
        textoDialogo.text = linea.texto;

        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;

        indiceDialogo++;
    }

    private void TerminarDialogo()
    {
        indiceDialogo = 0;
        dialogoActivo = false;

        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
}
