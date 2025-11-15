using UnityEngine;

public class GestorInventario : MonoBehaviour
{
    
    public GameObject MenuInventario;
    private bool menuAbierto;

    public EspacioObjeto[] espacio;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //comprobamos si el menú está abierto para actiavrlo o desactivarlo
        if (Input.GetButtonDown("Inventario") && menuAbierto)
        {
            //Reanudar juego
            Time.timeScale = 1;
            MenuInventario.SetActive(false);
            menuAbierto = false;
        }

        else if (Input.GetButtonDown("Inventario") && !menuAbierto)
        {
            //Pausar el juego
            Time.timeScale = 0;
            MenuInventario.SetActive(true);
            menuAbierto = true;
        }
    }

    public void AddItem(string nombre, int cantidad, Sprite sprite)
    {
        Debug.Log(nombre + ", " + cantidad + ", " + sprite);

        for (int i = 0; i < espacio.Length; i++)
        {
            if (!espacio[i].ocupado)
            {
                espacio[i].AddItem(nombre,cantidad,sprite);
                break;
            }
        }
    }
}
