using UnityEngine;

public class Hablar : MonoBehaviour
{
    private Rigidbody2D rb;
    //private Animator anim;
    public Animator bocadilloAnim;

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
}
