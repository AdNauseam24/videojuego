using UnityEngine;
using static TipoObjetoEnum;

public class Jugador : MonoBehaviour
{
    [SerializeField]
    private GestorInventario inventario;

    [SerializeField]
    private HIghlight highlight;

    [SerializeField]
    private Compendio compendio;

    private float contadorHerramienta;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (contadorHerramienta > 0)
        {
            contadorHerramienta -= Time.unscaledDeltaTime;
        }
        if (Input.GetMouseButtonDown(0) && contadorHerramienta <=0)
        {
            if(!inventario.GetMenuAbierto() && highlight.GetPosicionValida())
            {
                int idTemp = inventario.GetIdSeleccionadoHotbar();
                if (idTemp != -1 && compendio.GetObjeto(idTemp).GetTipoObjeto() == (int)TipoObjeto.Herramienta)
                {
                     compendio.GetObjeto(idTemp).UsarMapa(highlight.GetPosicion());
                     contadorHerramienta = 1;
                }
                
            }
        }
    }
}
