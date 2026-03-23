using System;
using UnityEngine;

public class Compendio : MonoBehaviour
{
    [SerializeField]
    private Objeto[] objetos;

    public static Compendio Instance;

    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public Objeto GetObjeto(int id)
    {
        return objetos[id];
    }
}
