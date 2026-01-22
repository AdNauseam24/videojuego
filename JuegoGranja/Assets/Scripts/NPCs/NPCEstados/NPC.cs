using UnityEngine;

public class NPC : MonoBehaviour
{
   public enum NPCState {Default, Idle, Patrulla, Hablar};
   public NPCState estadoActual = NPCState.Patrulla;
   private NPCState defaultState; 


   public Patrulla patrulla;
   public Hablar hablar;



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
