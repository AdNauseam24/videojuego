using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.EventSystems;
using UnityEditor;
using Unity.Mathematics;

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

   [SerializeField]
    private float tiempoPresion;

	private bool mantenido;

    private GestorInventario gestorInventario;

    [SerializeField]
    private bool usableDesdeMapa;

    [SerializeField]
    private bool consumible;

    void Start()
    {
      gestorInventario = GameObject.Find("Inventario").GetComponent<GestorInventario>();
    }

    void Update()
    {
		//Drop de objetos desde el inventario abierto
        if(gestorInventario.GetMenuAbierto() && seleccionado && ocupado)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                    tiempoPresion += Time.unscaledDeltaTime;
                    if(tiempoPresion >= 1.3f)
                    {
                        Debug.Log("Mantenido");
                        mantenido = true;
                        GestionDrop(true);

                    }
                
            }
            if (Input.GetKeyUp(KeyCode.Q))
            {
                if (!mantenido)
                {
                    Debug.Log("Levantado");
                    GestionDrop(false);
                }
                
                mantenido = false;
                tiempoPresion = 0;
            }
        }
    }


    public void AddItem(int id,string nombre, int cantidad, Sprite sprite, bool consumible, bool usableDesdeMapa)
    {
		this.id = id;
		this.nombre = nombre;
		this.cantidad = cantidad;
		this.sprite = sprite;
        this.consumible = consumible;
        this.usableDesdeMapa = usableDesdeMapa;
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
						this.AddItem(datosRecibidos.id,datosRecibidos.nombre,datosRecibidos.cantidad,datosRecibidos.sprite, datosRecibidos.consumible, datosRecibidos.usableDesdeMapa);
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
                        bool consumibleTemporal = datosRecibidos.consumible;
                        bool usableDesdeMapaTemporal = datosRecibidos.usableDesdeMapa;

						datosRecibidos.AddItem(this.id,this.nombre,this.cantidad,this.sprite, this.consumible, this.usableDesdeMapa);
						this.AddItem(idTemporal,nombreTemporal,cantidadTemporal,spritetemporal, consumibleTemporal, usableDesdeMapaTemporal);
					}

				gestorInventario.DeseleccionarTodo();
				marcoSeleccion.GetComponent<UnityEngine.UI.Image>().enabled = true;
				this.seleccionado = true;
			}
       
    }


	//Función para determinar la posición a la que se dropearán los objetos en función de la última dirección en la que haya mirado el jugador
	public void GestionDrop(bool todos)
    {
        Vector2 posicionPlayer = Movimiento.GetPosicion();
		Vector2 lugarDrop = posicionPlayer;
		string ultimaDireccion;

		switch( ultimaDireccion = Movimiento.GetUltimaDireccion())
        {
            case "up":
				lugarDrop += new Vector2(0,2);
				Debug.Log(lugarDrop);
			break;
			case "down":
				lugarDrop += new Vector2(0,-2);
			break;
			case "right":
				lugarDrop += new Vector2(2,0);
			break;
			case "left":
				lugarDrop += new Vector2(-2,0);
			break;
        }
        if (todos)
        {
            DropTodosObjetos(lugarDrop);
        }
        else
        {
            DropObjeto(lugarDrop);
        }
    }

	public void DropObjeto(Vector2 posicion)
    {
		//creamos el objeto
        Object prefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/ObjetoDrop.prefab", typeof(ObjetoDrop));
		ObjetoDrop drop = Instantiate(prefab,GameObject.FindGameObjectWithTag("ObjetosMapa").transform, true) as ObjetoDrop;

		//le damos los valores
		drop.transform.position = posicion;
		drop.SetCantidad(1);
		drop.SetId(this.id);

		//activamos
		drop.GetComponent<ObjetoDrop>().enabled = true;

		this.cantidad -= 1;
		this.textoCantidad.text = this.cantidad.ToString();
		if(this.cantidad  < 1)
        {
            this.RemoveItem();
        }
    }
	public void DropTodosObjetos(Vector2 posicion)
    {
        Object prefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/ObjetoDrop.prefab", typeof(ObjetoDrop));
		ObjetoDrop drop = Instantiate(prefab,GameObject.FindGameObjectWithTag("ObjetosMapa").transform, true) as ObjetoDrop;

		drop.transform.position = posicion;
		drop.SetCantidad(this.cantidad);
		drop.SetId(this.id);
		
		this.RemoveItem();

		drop.GetComponent<ObjetoDrop>().enabled = true;
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
