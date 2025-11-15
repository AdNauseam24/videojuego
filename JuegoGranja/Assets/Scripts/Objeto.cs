using System;
using UnityEngine;

public class Objeto : MonoBehaviour
{
    //para poder cambiar el nombre desde el editor de Unity
    [SerializeField]
    private string nombre;
     [SerializeField]
    private int cantidad;
     [SerializeField]
    private Sprite sprite;

    private GestorInventario gestorInventario;
    void Start()
    {
        //buscar el gameobject inventario y acceder al componente del gestor
        gestorInventario = GameObject.Find("Inventario").GetComponent<GestorInventario>();
    }

    //Cuando entra en contacto con
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gestorInventario.AddItem(nombre,cantidad,sprite);
            Destroy(gameObject);
        }
    }
}
