using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.EventSystems;

public class EspacioObjeto : MonoBehaviour, IPointerClickHandler, IDropHandler
{
    

   public string nombre;
   public int cantidad;
   public Sprite sprite;

   public Sprite spriteVacio;

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

    public void RemoveItem()
    {
        this.id = -1;
        this.nombre = null;
        this.cantidad = 0;
        this.sprite = null;
        ocupado = false;

        textoCantidad.text = cantidad.ToString();
        textoCantidad.enabled = false;
        imagenObjeto.sprite = spriteVacio;

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
        marcoSeleccion.GetComponent<UnityEngine.UI.Image>().enabled = true;
        seleccionado = true;
    }


    public void OnDrop(PointerEventData eventData)
    {
       GameObject dropped = eventData.pointerDrag;
       DraggingObjetos objetoDrop = dropped.GetComponent<DraggingObjetos>();
       EspacioObjeto datosRecibidos =  objetoDrop.parentAfterDrag.parent.GetComponent<EspacioObjeto>();
       if(!this.Equals(datosRecibidos)){
        if(!this.ocupado)
            {
             this.AddItem(datosRecibidos.id,datosRecibidos.nombre,datosRecibidos.cantidad,datosRecibidos.sprite);
             datosRecibidos.RemoveItem();
             
            }
        else if (this.id == datosRecibidos.id)
            {
                this.incrementarCantidad(datosRecibidos.cantidad);
                datosRecibidos.RemoveItem();
            }
            else
            {
                Sprite spritetemporal = datosRecibidos.sprite;
                int idTemporal = datosRecibidos.id;
                string nombreTemporal = datosRecibidos.nombre;
                int cantidadTemporal = datosRecibidos.cantidad;
                datosRecibidos.AddItem(this.id,this.nombre,this.cantidad,this.sprite);
                this.AddItem(idTemporal,nombreTemporal,cantidadTemporal,spritetemporal);
            }
            gestorInventario.DeseleccionarTodo();
            marcoSeleccion.GetComponent<UnityEngine.UI.Image>().enabled = true;
            this.seleccionado = true;
       }
       
    }
}
