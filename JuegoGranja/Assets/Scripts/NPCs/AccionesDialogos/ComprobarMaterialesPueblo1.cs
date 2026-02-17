using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "ComportamientoDerivadoPrueba", menuName = "Scriptable Objects/ComprobarMatsPueblo1")]
public class ComprobarMatsPueblo1 : ComportamientoBaseSO
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

        }
    }

    private void RequisitosCap1()
    {
        if(StatsGenerales.Instance.oro >= int.Parse(StatsGenerales.Instance.requisitosMisiones[StatsGenerales.Instance.capituloHistoria].Split()[0]) &&
            GestorInventario.Instance.CheckCantidad(int.Parse(StatsGenerales.Instance.requisitosMisiones[StatsGenerales.Instance.capituloHistoria].Split()[2]),int.Parse(StatsGenerales.Instance.requisitosMisiones[StatsGenerales.Instance.capituloHistoria].Split()[1])))
            {
                StatsGenerales.Instance.RestarOro(int.Parse(StatsGenerales.Instance.requisitosMisiones[StatsGenerales.Instance.capituloHistoria].Split()[0]));
                GestorInventario.Instance.RestarCantidad(int.Parse(StatsGenerales.Instance.requisitosMisiones[StatsGenerales.Instance.capituloHistoria].Split()[2]),int.Parse(StatsGenerales.Instance.requisitosMisiones[StatsGenerales.Instance.capituloHistoria].Split()[1]));
                StatsGenerales.Instance.puentePueblo1 = true;
                GestorDIalogos.Instance.TerminarDialogoScripted();
                GestorDIalogos.Instance.EmpezarDialogo(dialogosCumplido[StatsGenerales.Instance.capituloHistoria]);
                StatsGenerales.Instance.afinidadPueblo1++;
                StatsGenerales.Instance.ultimaAfinidad = 1;
            }
        else
        {
            GestorDIalogos.Instance.TerminarDialogoScripted();
            GestorDIalogos.Instance.EmpezarDialogo(noCumplido);
        }
    }
}
