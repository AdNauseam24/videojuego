using UnityEngine;

[CreateAssetMenu(fileName = "ComportamientoBaseSO", menuName = "Scriptable Objects/ComportamientoBaseSO")]
public class ComportamientoBaseSO : ScriptableObject
{
    public virtual void OnUse()
    {
        Debug.Log("Base Obj");
    }
}
