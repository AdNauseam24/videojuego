using System;
using UnityEngine;
using static TipoObjetoEnum;

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
    protected TipoObjeto tipoObjeto;

    protected GestorInventario gestorInventario;
    void Start()
    {
        //buscar el gameobject inventario y acceder al componente del gestor
        gestorInventario = GameObject.Find("Inventario").GetComponent<GestorInventario>();
    }

    public int UsarMapa(Vector2 posicion)
    {
        switch (this.id)
        {
            case 2:
                return UsarPico(posicion);
                

        }
        return -1;
    }

    private int UsarPico(Vector2 posicion)
    {
        if(Physics2D.OverlapCircle(posicion, .2f, LayerMask.GetMask("Piedras")))
        {
            RaycastHit2D hit = Physics2D.Raycast(posicion,new Vector2(1,1), 0.3f, LayerMask.GetMask("Piedras"));
            Rocas roca = hit.transform.gameObject.GetComponent<Rocas>();
            Debug.Log(roca.GetVida());
            roca.Romperse();
            return 1;
        }
        return -1;
    }
    private void UsarHacha(Vector2 psoicion)
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

    public int GetTipoObjeto()
    {
        return (int)tipoObjeto;
    }
}
