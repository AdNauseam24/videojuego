using UnityEngine;

public class GestorInventario : MonoBehaviour
{
    
    public GameObject MenuInventario;
    private bool menuAbierto;

    public EspacioObjeto[] espacio;

    public GameObject hotbar;
    void Start()
    {
        MenuInventario.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //comprobamos si el menú está abierto para actiavrlo o desactivarlo
        if (Input.GetButtonDown("Inventario") && menuAbierto)
        {
            //Reanudar juego
            Time.timeScale = 1;
            hotbar.transform.SetParent(GameObject.FindGameObjectWithTag("Inventario").transform);
            hotbar.transform.localPosition = new Vector3(-690,-300);
            MenuInventario.SetActive(false);
            menuAbierto = false;
        }

        else if (Input.GetButtonDown("Inventario") && !menuAbierto)
        {
            //Pausar el juego
            Time.timeScale = 0;
            MenuInventario.SetActive(true);
            hotbar.transform.SetParent(GameObject.FindGameObjectWithTag("Huecos").transform);

            //para que sea la primera fila
            hotbar.transform.SetSiblingIndex(0);
            menuAbierto = true;
        }
    }

    public void AddItem(int id,string nombre, int cantidad, Sprite sprite)
    {
        Debug.Log(id + ", " + nombre + ", " + cantidad + ", " + sprite);

        int indiceLibre = -1;
        bool encontrado = false;

        for (int i = 0; i < espacio.Length; i++)
        {
            if(espacio[i].id == id)
            {
                espacio[i].incrementarCantidad(cantidad);
                encontrado = true;
              
                break;
            }
            if ( indiceLibre == -1 && !espacio[i].ocupado )
            {
                indiceLibre = i;
                
            }
        }
        if (!encontrado && indiceLibre !=-1)
        {
            Debug.Log("Añadiendo");
            espacio[indiceLibre].AddItem(id,nombre,cantidad,sprite);
            Debug.Log("Añadido");
        }
    }
}
