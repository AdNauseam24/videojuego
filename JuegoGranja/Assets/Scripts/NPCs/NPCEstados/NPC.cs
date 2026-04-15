using UnityEngine;
using UnityEngine.EventSystems;

public class NPC : MonoBehaviour, IPointerClickHandler
{
   public enum NPCState {Default, Idle, Patrulla, Hablar};
   public NPCState estadoActual = NPCState.Patrulla;
   private NPCState defaultState; 

   public ActorSO actorSO;


   public Patrulla patrulla;
   public Hablar hablar;

   public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left && estadoActual == NPCState.Hablar && actorSO.aplicable)
        {
            if(!GestorInventario.Instance.GetMenuAbierto() && !GestorDIalogos.Instance.dialogoActivo)
            {
                if(GestorInventario.Instance.GetIdSeleccionadoHotbar() > 6)
                {
                    DarRegalo.Instance.EmpezarProceso(actorSO,GestorInventario.Instance.GetIdSeleccionadoHotbar());
                }
            }
        }
    }



    void Start()
    {
        defaultState = estadoActual;

        SwitchState(estadoActual);
    }

    public void SwitchState(NPCState nuevoEstado)
    {
        estadoActual = nuevoEstado;
        patrulla.enabled = nuevoEstado == NPCState.Patrulla;
        hablar.enabled = nuevoEstado == NPCState.Hablar;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SwitchState(NPCState.Hablar);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SwitchState(defaultState);
        }
    }
}
