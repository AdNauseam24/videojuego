using System.Collections.Generic;
using UnityEngine;

public class Hablar : MonoBehaviour
{
    private Rigidbody2D rb;
    //private Animator anim;
    public Animator bocadilloAnim;
    public List<DialogoSO> conversaciones;
    public DialogoSO conversacionActual;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
       // anim = GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
        rb.linearVelocity = Vector2.zero;
       // anim.Play("Idle");
        bocadilloAnim.Play("Abrir");
    }
    private void OnDisable()
    {
        bocadilloAnim.Play("Cerrar");
    }
    private void Update()
    {
        if (Input.GetButtonDown("Interactuar"))
        {
            if (GestorDIalogos.Instance.dialogoActivo)
            {
                GestorDIalogos.Instance.AvanzarDialogo();
            }
            else
            {
                CheckNuevaConversacion();
                GestorDIalogos.Instance.EmpezarDialogo(conversacionActual);
                GestorInventario.Instance.DesactivarHotbar();
                Time.timeScale = 0;
            }
        }
    }
    private void CheckNuevaConversacion()
    {
        for (int i =  conversaciones.Count -1 ; i >= 0; i++)
        {
            var convo = conversaciones[i];
            if(convo != null && convo.condicionCumplida())
            {
                conversacionActual = convo;
                if (convo.removeAfterPlay)
                {
                    conversaciones.RemoveAt(i);
                }

                if(convo.removeListAfterPlay != null && convo.removeListAfterPlay.Count > 0)
                {
                    foreach (var quitar in convo.removeListAfterPlay)
                    {
                        conversaciones.Remove(quitar);
                    }
                }
             
                break;
            }
        }
    }
}
