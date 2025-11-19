using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.EventSystems;

public class EspacioObjeto : MonoBehaviour, IPointerClickHandler, IDropHandler
{
	[SerializeField]
   private int id;

	[SerializeField]
   private string nombre;

	[SerializeField]
   private int cantidad;

	[SerializeField]
   private Sprite sprite;

	[SerializeField]
   private Sprite spriteVacio;

	[SerializeField]
   private bool ocupado;

   [SerializeField]
   private TMP_Text textoCantidad;

   [SerializeField]
   private Image imagenObjeto;

	[SerializeField]
   private GameObject marcoSeleccion;

	[SerializeField]
   private bool seleccionado;

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
		if(eventData.button == PointerEventData.InputButton.Left && gestorInventario.GetMenuAbierto())
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
		//El game object que se suelta sobre el espacio
       GameObject dropped = eventData.pointerDrag;
       DraggingObjetos objetoDrop = dropped.GetComponent<DraggingObjetos>();

		 //El padre del objeto que se ha soltado es decir, otro espacio de objetos con su información correspondiente
       EspacioObjeto datosRecibidos =  objetoDrop.parentAfterDrag.parent.GetComponent<EspacioObjeto>();

       if(!this.Equals(datosRecibidos) && datosRecibidos.GetOcupado() && gestorInventario.GetMenuAbierto())
			{
				if(!this.ocupado)
					{
						this.AddItem(datosRecibidos.id,datosRecibidos.nombre,datosRecibidos.cantidad,datosRecibidos.sprite);
						datosRecibidos.RemoveItem();
					}

				else if(this.id == datosRecibidos.id)
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

	 public bool GetOcupado()
    {
        return ocupado;
    }
	 public int GetId()
    {
        return id;
    }
	 public GameObject GetMarcoSeleccion()
    {
        return marcoSeleccion;
    }
	 public void SetSeleccionado(bool seleccionado)
    {
		this.seleccionado = seleccionado;
        if (seleccionado)
        {
            marcoSeleccion.GetComponent<UnityEngine.UI.Image>().enabled = true;
        }
        else
        {
            marcoSeleccion.GetComponent<UnityEngine.UI.Image>().enabled = false;
        }
        
    }

	 public bool GetSeleccionado()
    {
        return seleccionado;
    }
}
