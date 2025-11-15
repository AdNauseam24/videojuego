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
