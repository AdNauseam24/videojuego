using TMPro;
using UnityEngine;

public class Hotbar : MonoBehaviour
{
   
    [SerializeField]
    private GestorInventario gestorInventario;

    [SerializeField]
    private EspacioObjeto[] espacios;

    [SerializeField]
    private int rememberSeleccionado;

    [SerializeField]
    private float tiempoPresion;

    private bool mantenido;

    private KeyCode[] keyCodes = {KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8};
    void Start()
    {
        rememberSeleccionado = 0;
        espacios[0].SetSeleccionado(true);
    }

    private int botonPresionado;
    private int num = -1;
    void Update()
    {
    
        //movilidad de la selección de espacios
        if(!gestorInventario.GetMenuAbierto())
        {
            //checkeamos si algún número del 1 al 8 es pulsado
            for( int i = 0 ; i < keyCodes.Length ; ++i )
            {
                if( Input.GetKeyDown( keyCodes[i]) && botonPresionado == 0)
                {
                    //Para evitar que se presione otro hasta que soltemos la tecla
                    botonPresionado = 1;
                    num = i;
                    gestorInventario.DeseleccionarTodo();
                    espacios[i].SetSeleccionado(true);
                    rememberSeleccionado = i;
                }
                
            }
            if (botonPresionado == 1 && num!= -1 && Input.GetKeyUp(keyCodes[num]))
            {
                num = -1;
                botonPresionado = 0;
            }

            //comprobamos si se detecta la rueda del ratón y según la dirección cambiamos la selección hacia un lado u otro
            if(botonPresionado == 0 && Input.mouseScrollDelta.y != 0)
            {
                if( Input.mouseScrollDelta.y > 0 && rememberSeleccionado < espacios.Length-1)
                {
                    rememberSeleccionado+=1;
                    gestorInventario.DeseleccionarTodo();
                    espacios[rememberSeleccionado].SetSeleccionado(true);
                }
                 else if (Input.mouseScrollDelta.y < 0  && rememberSeleccionado > 0)
                {
                    rememberSeleccionado-=1;
                    gestorInventario.DeseleccionarTodo();
                    espacios[rememberSeleccionado].SetSeleccionado(true);
                }
            }
            //drop de objetos
            if (Input.GetKey(KeyCode.Q))
            {
                if(espacios[rememberSeleccionado].GetOcupado())
                {
                    botonPresionado = 1;
                    tiempoPresion += Time.deltaTime;
                    if(tiempoPresion >= 1.3f)
                    {
                        Debug.Log("Mantenido");
                        mantenido = true;
                        espacios[rememberSeleccionado].GestionDrop(true);

                    }
                }
            }
            if (botonPresionado == 1 && Input.GetKeyUp(KeyCode.Q))
            {
                if (!mantenido)
                {
                    Debug.Log("Levantado");
                    espacios[rememberSeleccionado].GestionDrop(false);
                }
                
                mantenido = false;
                tiempoPresion = 0;
                botonPresionado = 0;
            }
            
        }
       
    }

    //Activar/desactivar los números de acceso rápido de la hotbar
    public void DesactivarHUecos()
    {
        foreach (var espacio in espacios)
        {
            espacio.transform.Find("Seleccionado/NumTecla").GetComponent<TMP_Text>().enabled = false;
        }
    }
    public void ActivarHuecos()
    {
        foreach (var espacio in espacios)
        {
            espacio.transform.Find("Seleccionado/NumTecla").GetComponent<TMP_Text>().enabled = true;
        }
    }



    public int GetRememberSeleccionado()
    {
        return rememberSeleccionado;
    }

    public EspacioObjeto GetEspacioObjeto(int n)
    {
        return espacios[n];
    }

    public int GetIdSeleccionado()
    {
        if (espacios[rememberSeleccionado].GetOcupado())
        {
            return espacios[rememberSeleccionado].GetId();
        }
        return -1;
    }

    
}
