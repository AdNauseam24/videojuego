using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.EventSystems;

public class EspacioObjeto : MonoBehaviour, IPointerClickHandler
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

   public GameObject marcoSeleccion;
   public bool seleccionado;

    private GestorInventario gestorInventario;

    void Start()
    {
        gestorInventario = GameObject.Find("Inventario").GetComponent<GestorInventario>();
    }


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

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left && gestorInventario.menuAbierto)
        {
            ClickIzquierdo();
        }
    }

    public void ClickIzquierdo()
    {
        gestorInventario.DeseleccionarTodo();
        marcoSeleccion.SetActive(true);
        seleccionado = true;
    }
}
