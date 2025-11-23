using Unity.VisualScripting;
using UnityEngine;

public class ObjetoDrop : Objeto 
{
    private Compendio compendio;

    [SerializeField]
    private int cantidad;
    [SerializeField]
    private SpriteRenderer imagen;
    
    void Start()
    {
        this.gestorInventario = GameObject.Find("Inventario").GetComponent<GestorInventario>();
        this.compendio = GameObject.FindAnyObjectByType<Compendio>();
        this.nombre = compendio.GetObjeto(id).GetNombre();
        this.sprite = compendio.GetObjeto(id).GetSprite();
        this.imagen.sprite = this.sprite;
        this.usableDesdeMapa = compendio.GetObjeto(id).GetUsableMapa();
        this.consumible = compendio.GetObjeto(id).GetConsumible();
        
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
            gestorInventario.AddItem(id,nombre,cantidad,sprite, consumible, usableDesdeMapa);
            Destroy(gameObject);
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
