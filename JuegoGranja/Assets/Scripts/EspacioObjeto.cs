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

   [SerializeField]
   private TMP_Text textoCantidad;

   [SerializeField]
   private Image imagenObjeto;

   public void AddItem(string nombre, int cantidad, Sprite sprite)
    {
        this.nombre = nombre;
        this.cantidad = cantidad;
        this.sprite = sprite;
        ocupado = true;

        textoCantidad.text = cantidad.ToString();
        textoCantidad.enabled = true;
        imagenObjeto.sprite = sprite;
        
    }
   
}
