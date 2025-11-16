using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class EspacioObjeto : MonoBehaviour
{
   public string nombre;
   public int cantidad;
   public Sprite sprite;

   public bool ocupado;

   public int id;

   [SerializeField]
   private TMP_Text textoCantidad;

   [SerializeField]
   private Image imagenObjeto;



    public void AddItem(int id,string nombre, int cantidad, Sprite sprite)
    {
        this.id = id;
        this.nombre = nombre;
        this.cantidad = cantidad;
        this.sprite = sprite;
        ocupado = true;

        textoCantidad.text = cantidad.ToString();
        textoCantidad.enabled = true;
        imagenObjeto.sprite = sprite;
        
    }
   
   public void incrementarCantidad(int cantidad)
    {
         this.cantidad += cantidad;
         textoCantidad.text = this.cantidad.ToString();
    }
}
