using UnityEngine;

public class GestorPueblo1 : MonoBehaviour
{
    void OnEnable()
    {
        GestorTenderos.Instance.ActivarTenderosPueblo1();
    }

    void OnDisable()
    {
        GestorTenderos.Instance.DesactivarTenderosPueblo1();
    }
}
