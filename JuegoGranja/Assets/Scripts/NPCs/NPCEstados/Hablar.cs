using UnityEngine;

public class Hablar : MonoBehaviour
{
    private Rigidbody2D rb;
    //private Animator anim;
    public Animator bocadilloAnim;
    public DialogoSO dialogoSO;

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
                GestorDIalogos.Instance.EmpezarDialogo(dialogoSO);
            }
        }
    }
}
