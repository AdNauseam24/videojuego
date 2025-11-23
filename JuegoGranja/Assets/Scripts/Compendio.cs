using System;
using UnityEngine;

public class Compendio : MonoBehaviour
{
    [SerializeField]
    private Objeto[] objetos;
    

    public static explicit operator Compendio(GameObject v)
    {
        throw new NotImplementedException();
    }

    public Objeto GetObjeto(int id)
    {
        return objetos[id];
    }
}
