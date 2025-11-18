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
        this.nombre = compendio.objetos[id].GetNombre();
        this.sprite = compendio.objetos[id].GetSprite();
        this.imagen.sprite = this.sprite;
        
    }

    //Cuando entra en contacto con
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gestorInventario.AddItem(id,nombre,cantidad,sprite);
            Destroy(gameObject);
        }
    }
}
