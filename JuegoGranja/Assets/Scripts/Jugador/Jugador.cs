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

    public static Jugador Instance;
    void Awake()
    {
         if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }


    void Update()
    {
        if (contadorHerramienta > 0)
        {
            contadorHerramienta -= Time.unscaledDeltaTime;
        }
        if (Input.GetMouseButtonDown(0) && contadorHerramienta <=0)
        {
            if(!inventario.GetMenuAbierto() && highlight.GetPosicionValida() && !GestorDIalogos.Instance.dialogoActivo)
            {
                int idTemp = inventario.GetIdSeleccionadoHotbar();
                if(idTemp >= 14 && idTemp <=18)
                {
                    int n = compendio.GetObjeto(idTemp).UsarSemilla(highlight.GetPosicion(), idTemp);
                    if (n == 1)
                    {
                        inventario.hotbar.GetEspacioObjeto(inventario.hotbar.GetRememberSeleccionado()).ReducirUno();
                    }
                }
                else if (idTemp != -1 && compendio.GetObjeto(idTemp).GetTipoObjeto() == (int)TipoObjeto.Herramienta )
                {
                    if(StatsGenerales.Instance.energia >= 2)
                    {
                     compendio.GetObjeto(idTemp).UsarMapa(highlight.GetPosicion());
                     contadorHerramienta = 1;
                     StatsGenerales.Instance.RestarEnergia(2);
                    }
                    else
                    {
                        contadorHerramienta = 1;
                        StatsGenerales.Instance.AgitarBarra();
                    }
                }
                
            }
        }
    }
}
