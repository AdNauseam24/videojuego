using UnityEngine;

[CreateAssetMenu(fileName = "ComportamientoDerivadoPrueba", menuName = "Scriptable Objects/ComportamientoDerivadoPrueba")]
public class ComportamientoDerivadoPrueba : ComportamientoBaseSO
{
    public delegate void DialogoTerminado();
    public static event DialogoTerminado OnDialogoTerminado;
     public override void OnUse()
    {
        GestorDIalogos.Instance.TerminarDialogoScripted();
        OnDialogoTerminado();
    }
}
