using System;
using UnityEngine;

public class Objeto : MonoBehaviour
{
    //para poder cambiar el nombre desde el editor de Unity
    [SerializeField]
    protected string nombre;
   
     [SerializeField]
    protected Sprite sprite;

    [SerializeField]
    protected int id;

    [SerializeField]
    protected bool usableDesdeMapa;

     [SerializeField]
    protected bool consumible;

    protected GestorInventario gestorInventario;
    void Start()
    {
        //buscar el gameobject inventario y acceder al componente del gestor
        gestorInventario = GameObject.Find("Inventario").GetComponent<GestorInventario>();
    }

    public void UsarMapa(Vector2 posicion)
    {
        switch (this.id)
        {
            case 2:
                UsarPico(posicion);
                break;

        }
    }

    public void UsarPico(Vector2 posicion)
    {
        Debug.Log(posicion);
    }
    public void UsarHacha(Vector2 psoicion)
    {
        
    }

    public string GetNombre()
    {
        return nombre;
    }
    public Sprite GetSprite()
    {
        return sprite;
    }

    public bool GetConsumible()
    {
        return this.consumible;
    }

    public bool GetUsableMapa()
    {
        return this.usableDesdeMapa;
    }
}
