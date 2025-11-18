using System;
using UnityEngine;

public class Compendio : MonoBehaviour
{
    public Objeto[] objetos;
    

    public static explicit operator Compendio(GameObject v)
    {
        throw new NotImplementedException();
    }
}
