using Unity.VisualScripting;
using UnityEngine;

public class ObjetoDrop : Objeto 
{
    public Compendio compendio;

    [SerializeField]
    private int cantidad;
    [SerializeField]
    private SpriteRenderer imagen;
    
    public ObjetoDrop()
    {
       
    }
    void Start()
    {
        this.gestorInventario = GameObject.Find("Inventario").GetComponent<GestorInventario>();
        this.compendio = GameObject.FindAnyObjectByType<Compendio>();
        this.nombre = compendio.objetos[id].GetNombre();
        this.sprite = compendio.objetos[id].GetSprite();
        this.imagen.sprite = this.sprite;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
