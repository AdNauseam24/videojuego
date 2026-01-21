using Unity.VisualScripting;
using UnityEngine;

public class ObjetoDrop : Objeto 
{
    private Compendio compendio;

    [SerializeField]
    private int cantidad;
    [SerializeField]
    private SpriteRenderer imagen;

    [SerializeField]
    private Animator animator;
    
    void Start()
    {
        this.gestorInventario = GameObject.Find("Inventario").GetComponent<GestorInventario>();
        this.compendio = GameObject.FindAnyObjectByType<Compendio>();
        this.nombre = compendio.GetObjeto(id).GetNombre();
        Debug.Log(nombre);
        this.sprite = compendio.GetObjeto(id).GetSprite();
        Debug.Log(sprite);
        this.imagen.sprite = this.sprite;
    }

    public ObjetoDrop(int id)
    {
        this.id = id;
    }

    //Cuando entra en contacto con
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            animator.SetBool("Recoger",true);
            gestorInventario.AddItem(id,nombre,cantidad,sprite);
            Destroy(gameObject, .5f);
        }
    }

    public void SetCantidad(int n)
    {
        cantidad = n;
    }
    public void SetId(int n)
    {
        this.id = n;
    }
}
