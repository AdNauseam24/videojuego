using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tuberia : MonoBehaviour,  IPointerClickHandler
{
   public bool arriba;
   public bool derecha;
   public bool abajo;
   public bool izquierda;

   public Tuberia tuberiaArriba;
   public Tuberia tuberiaDerecha;
   public Tuberia tuberiaAbajo;
   public Tuberia tuberiaIzquierda;

   public bool conectadoArriba;
   public bool conectadoDerecha;
   public bool conectadoAbajo;
   public bool conectadoIzquierda;

   public bool activo;
   public bool fuente;

    //0 vacío, 1 lleno
   public Sprite[] sprites;

    public delegate void TuberiaGirada();
    public static event TuberiaGirada OnTuberiaGirada;


    private void RotarTuberia()
    {
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z - 90);
        bool tempConectArriba = conectadoArriba;
        bool tempConectDerecha = conectadoDerecha;
        bool tempConectAbajo = conectadoAbajo;
        bool tempConectIzda = conectadoIzquierda;
        bool tempIzda = izquierda;
        izquierda = abajo;
        abajo = derecha;
        derecha = arriba;
        arriba = tempIzda;


        if(arriba && tuberiaArriba != null && tuberiaArriba.abajo)
        {
           conectadoArriba = true;
           tuberiaArriba.conectadoAbajo = true;
        }
        else if(tuberiaArriba !=null)
        {
            conectadoArriba = false;
            tuberiaArriba.conectadoAbajo = false;
        }
        else
        {
            conectadoArriba = false;
        }


        if(derecha && tuberiaDerecha != null && tuberiaDerecha.izquierda)
        {
            conectadoDerecha = true;
            tuberiaDerecha.conectadoIzquierda = true;
        }
        else if(tuberiaDerecha != null)
        {
            conectadoDerecha = false;
            tuberiaDerecha.conectadoIzquierda = false;
        }
        else
        {
            conectadoDerecha = false;
        }


        if(abajo && tuberiaAbajo != null  && tuberiaAbajo.arriba)
        {
            conectadoAbajo = true;
            tuberiaAbajo.conectadoArriba = true;
        }
        else if(tuberiaAbajo != null)
        {
            conectadoAbajo = false;
            tuberiaAbajo.conectadoArriba = false;
        }
        else
        {
            conectadoAbajo = false;
        }


        if(izquierda && tuberiaIzquierda != null  && tuberiaIzquierda.derecha)
        {
            conectadoIzquierda = true;
            tuberiaIzquierda.conectadoDerecha = true;
        }
        else if(tuberiaIzquierda != null)
        {
            conectadoIzquierda = false;
            tuberiaIzquierda.conectadoDerecha = false;
        }
        else
        {
            conectadoIzquierda = false;
        }

        if(tempConectArriba && !conectadoArriba && tuberiaArriba.activo)
        {
            if (!tuberiaArriba.ConectadaAFuente(2))
            {
                tuberiaArriba.DesactivarTuberia();
            }
        }
        if(tempConectDerecha && !conectadoDerecha && tuberiaDerecha.activo)
        {
            if (!tuberiaDerecha.ConectadaAFuente(3))
            {
                tuberiaDerecha.DesactivarTuberia();
            }
        }
        if(tempConectAbajo && !conectadoAbajo && tuberiaAbajo.activo)
        {
            if (!tuberiaAbajo.ConectadaAFuente(0))
            {
                tuberiaAbajo.DesactivarTuberia();
            }
        }
        if(tempConectIzda && !conectadoIzquierda && tuberiaIzquierda.activo)
        {
            if (!tuberiaIzquierda.ConectadaAFuente(1))
            {
                tuberiaIzquierda.DesactivarTuberia();
            }
        }

        if (fuente)
        {
            ActivarAdyacentes();
            return;
        }


        if (activo)
        {
            ComprobarLadosActivo();
        }
        else
        {
            ComprobarLadosInactivo();
        }
        OnTuberiaGirada();
    }

    private void ComprobarLadosActivo()
    {

        if (!conectadoArriba && !conectadoDerecha && !conectadoAbajo && !conectadoIzquierda)
        {
            DesactivarTuberia();
            return;
        }
        if (!ConectadaAFuente(-1))
        {
            DesactivarTuberia();
        }
        else
        {
            ActivarAdyacentes();
        }

    }

    //-1 esta misma, 0 arriba, 1 derecha, 2 abajo, 3 izda
    public bool ConectadaAFuente(int origen)
    {
        if (fuente)
        {
            return true;
        }
        if (!activo)
        {
            return false;
        }
        else
        {
            bool[] ladosAComprobar = new bool[4];
            
        
            if(conectadoArriba && origen != 0)
                ladosAComprobar[0] = true;
            if(conectadoDerecha && origen != 1)
                ladosAComprobar[1] = true;
            if(conectadoAbajo && origen != 2)
                ladosAComprobar[2] = true;
            if(conectadoIzquierda && origen != 3)
                ladosAComprobar[3] = true;
                       
            bool[] tieneOrigen = new bool[4];

            for (int i = 0; i < ladosAComprobar.Length; i++)
            {
                if (ladosAComprobar[i])
                {
                    switch (i)
                    {
                        case 0:
                            tieneOrigen[i] = tuberiaArriba.ConectadaAFuente(2);
                            break;
                        case 1:
                            tieneOrigen[i] = tuberiaDerecha.ConectadaAFuente(3);
                            break;
                        case 2:
                            tieneOrigen[i] = tuberiaAbajo.ConectadaAFuente(0);
                            break;
                        case 3:
                            tieneOrigen[i] = tuberiaIzquierda.ConectadaAFuente(1);
                            break;

                    }
                    if(tieneOrigen[i])
                        return true;
                }
            }
            return false;
        }
    }

    public void DesactivarTuberia()
    {
        activo = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];

        if(conectadoArriba && tuberiaArriba.activo)
            tuberiaArriba.DesactivarTuberia();
        
        if(conectadoDerecha && tuberiaDerecha.activo)
            tuberiaDerecha.DesactivarTuberia();
        
        if(conectadoAbajo && tuberiaAbajo.activo)
            tuberiaAbajo.DesactivarTuberia();
        
        if(conectadoIzquierda && tuberiaIzquierda.activo)
            tuberiaIzquierda.DesactivarTuberia();

    }

    private void ComprobarLadosInactivo()
    {
        if(conectadoArriba && tuberiaArriba.activo)
        {
            ActivarTuberia();
            return;
        }
        if(conectadoDerecha && tuberiaDerecha.activo )
        {
            ActivarTuberia();
            return;
        }
        if(conectadoAbajo && tuberiaAbajo.activo)
        {
            ActivarTuberia();
            return;
        }
         if(conectadoIzquierda && tuberiaIzquierda.activo )
        {
            ActivarTuberia();
            return;
        }
    }

    public void ActivarTuberia()
    {
        activo = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];

        ActivarAdyacentes();
    }

    private void ActivarAdyacentes()
    {
       if(conectadoArriba && !tuberiaArriba.activo)
        {
            tuberiaArriba.ActivarTuberia();
        }
         if(conectadoDerecha && !tuberiaDerecha.activo)
        {
            tuberiaDerecha.ActivarTuberia();
        }
         if(conectadoAbajo && !tuberiaAbajo.activo)
        {
            tuberiaAbajo.ActivarTuberia();
        }
         if(conectadoIzquierda && !tuberiaIzquierda.activo)
        {
            tuberiaIzquierda.ActivarTuberia();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            RotarTuberia();
        }
    }
}
