using UnityEngine;

[CreateAssetMenu(fileName = "ComportamientoDerivadoPrueba", menuName = "Scriptable Objects/ComportamientoDerivadoPrueba")]
public class ComportamientoDerivadoPrueba : ComportamientoBaseSO
{
     public override void OnUse()
    {
        Debug.Log("derived");
    }
}
