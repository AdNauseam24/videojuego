using UnityEngine;

public class Polvo : MonoBehaviour
{
    public Rocas roca;

    public void dropObjeto()
    {
        Debug.Log("Polvo");
        roca.dropObjeto();
    }
}
