using System;
using UnityEngine;

public class Compendio : MonoBehaviour
{
    public Objeto[] objetos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static explicit operator Compendio(GameObject v)
    {
        throw new NotImplementedException();
    }
}
