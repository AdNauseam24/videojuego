using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "ComportamientoDerivadoPrueba", menuName = "Scriptable Objects/ComprobarMatsPueblo2")]
public class ComprobarMatsPueblo2 : ComportamientoBaseSO
{
    public DialogoSO[] dialogosCumplido;
    public DialogoSO noCumplido;
     public override void OnUse()
    {
        switch (StatsGenerales.Instance.capituloHistoria)
        {
            case 0:
                RequisitosCap1();
                 break;

            case 1:
                RequisitosCap2();
                break;

        }
    }

    private void RequisitosCap1()
    {
        if(StatsGenerales.Instance.oro >= int.Parse(StatsGenerales.Instance.requisitosMisiones[StatsGenerales.Instance.capituloHistoria].Split()[0]) &&
            GestorInventario.Instance.CheckCantidad(int.Parse(StatsGenerales.Instance.requisitosMisiones[StatsGenerales.Instance.capituloHistoria].Split()[2]),int.Parse(StatsGenerales.Instance.requisitosMisiones[StatsGenerales.Instance.capituloHistoria].Split()[1])))
            {
                StatsGenerales.Instance.RestarOro(int.Parse(StatsGenerales.Instance.requisitosMisiones[StatsGenerales.Instance.capituloHistoria].Split()[0]));
                GestorInventario.Instance.RestarCantidad(int.Parse(StatsGenerales.Instance.requisitosMisiones[StatsGenerales.Instance.capituloHistoria].Split()[2]),int.Parse(StatsGenerales.Instance.requisitosMisiones[StatsGenerales.Instance.capituloHistoria].Split()[1]));
                StatsGenerales.Instance.PuentePueblo2 = true;
                GestorDIalogos.Instance.TerminarDialogoScripted();
                GestorDIalogos.Instance.EmpezarDialogo(dialogosCumplido[StatsGenerales.Instance.capituloHistoria]);
                StatsGenerales.Instance.afinidadPueblo2++;
                StatsGenerales.Instance.ultimaAfinidad = 2;
                StatsGenerales.Instance.entregado = true;
            }
        else
        {
            GestorDIalogos.Instance.TerminarDialogoScripted();
            GestorDIalogos.Instance.EmpezarDialogo(noCumplido);
        }
    }

    private void RequisitosCap2()
    {
        if(StatsGenerales.Instance.oro >= int.Parse(StatsGenerales.Instance.requisitosMisiones[StatsGenerales.Instance.capituloHistoria].Split()[0]) &&
            GestorInventario.Instance.CheckCantidad(int.Parse(StatsGenerales.Instance.requisitosMisiones[StatsGenerales.Instance.capituloHistoria].Split()[2]),int.Parse(StatsGenerales.Instance.requisitosMisiones[StatsGenerales.Instance.capituloHistoria].Split()[1])))
            {
                StatsGenerales.Instance.RestarOro(int.Parse(StatsGenerales.Instance.requisitosMisiones[StatsGenerales.Instance.capituloHistoria].Split()[0]));
                GestorInventario.Instance.RestarCantidad(int.Parse(StatsGenerales.Instance.requisitosMisiones[StatsGenerales.Instance.capituloHistoria].Split()[2]),int.Parse(StatsGenerales.Instance.requisitosMisiones[StatsGenerales.Instance.capituloHistoria].Split()[1]));
                //StatsGenerales.Instance.PuentePueblo2 = true;
                GestorDIalogos.Instance.TerminarDialogoScripted();
                GestorDIalogos.Instance.EmpezarDialogo(dialogosCumplido[StatsGenerales.Instance.capituloHistoria]);
                StatsGenerales.Instance.afinidadPueblo2++;
                StatsGenerales.Instance.ultimaAfinidad = 2;
                StatsGenerales.Instance.entregado = true;
            }
        else
        {
            GestorDIalogos.Instance.TerminarDialogoScripted();
            GestorDIalogos.Instance.EmpezarDialogo(noCumplido);
        }
    }
}
