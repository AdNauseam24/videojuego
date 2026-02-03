using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class GestorInventario : MonoBehaviour
{
    public static GestorInventario Instance;
    [SerializeField]
    private GameObject MenuInventario;

    private bool menuAbierto;

    public EspacioObjeto[] espacio;

    public Hotbar hotbar;

    [SerializeField]
    private Compendio compendio;

    [SerializeField]
    private HIghlight hIghlight;

    [SerializeField]
    private GameObject hotbarGO;

    void Awake()
    {
         if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    void Start()
    {
        MenuInventario.SetActive(false);
    }

    void Update()
    {
        //comprobamos si el menú está abierto para actiavrlo o desactivarlo
        if (Input.GetButtonDown("Inventario") && menuAbierto)
        {
            //Reanudar juego
            Time.timeScale = 1;

            //cambiamos el padre de la hotbar
            hotbar.transform.SetParent(GameObject.FindGameObjectWithTag("Inventario").transform);
            hotbar.transform.localPosition = new Vector3(-690,-300);
            hotbar.ActivarHuecos();

            //desactivamos y cerramos
            DeseleccionarTodo();
            MenuInventario.SetActive(false);
            menuAbierto = false;

            //Al cerrar reactivamos la casilla de la hotbar que estaba activada
            hotbar.GetEspacioObjeto(hotbar.GetRememberSeleccionado()).SetSeleccionado(true);
        }

        else if (Input.GetButtonDown("Inventario") && !menuAbierto && Time.timeScale == 1)
        {
            //Pausar el juego
            Time.timeScale = 0;

            //movemos la hotbar al menú
            MenuInventario.SetActive(true);
            hotbar.transform.SetParent(GameObject.FindGameObjectWithTag("Huecos").transform);
            hotbar.DesactivarHUecos();

            //para que sea la primera fila
            hotbar.transform.SetSiblingIndex(0);

            menuAbierto = true;

            DeseleccionarTodo();
        }
    }

    public void DesactivarHotbar()
    {
       hotbarGO.SetActive(false);
    }

    public void ActivarHotbar()
    {
       hotbarGO.SetActive(true);
    }
    public void AddItem(int id,string nombre, int cantidad, Sprite sprite)
    {
        Debug.Log(id + ", " + nombre + ", " + cantidad + ", " + sprite);

        int indiceLibre = -1;
        bool encontrado = false;

        for (int i = 0; i < espacio.Length; i++)
        {
            if(espacio[i].GetId() == id)
            {
                espacio[i].incrementarCantidad(cantidad);
                encontrado = true;
              
                break;
            }
            if ( indiceLibre == -1 && !espacio[i].GetOcupado())
            {
                indiceLibre = i;
                
            }
        }
        if (!encontrado && indiceLibre !=-1)
        {
            espacio[indiceLibre].AddItem(id,nombre,cantidad,sprite);
            Debug.Log("Añadido");
        }
    }

    public void DeseleccionarTodo()
    {
        for (int i = 0; i < espacio.Length; i++)
        {
            espacio[i].SetSeleccionado(false);
        }
    }

    public bool GetMenuAbierto()
    {
        return menuAbierto;
    }

    public int GetIdSeleccionadoHotbar()
    {
        return hotbar.GetIdSeleccionado();
    }

    public bool VenderObjeto(int id)
    {
         for (int i = 0; i < espacio.Length; i++)
        {
            if(espacio[i].GetId() == id)
            {
                espacio[i].ReducirUno();
                return true;
            }
        }
        return false;
    }
}
