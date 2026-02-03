using UnityEngine;

public class GestorTenderos : MonoBehaviour
{
   public static GestorTenderos Instance;
   [SerializeField] private Tendero[] tenderos;

     private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ActivarTenderosPueblo1()
    {
        for (int i = 0; i < 3; i++)
        {
            tenderos[i].gameObject.SetActive(true);
        }
    }
      public void DesactivarTenderosPueblo1()
    {
        for (int i = 0; i < 3; i++)
        {
            tenderos[i].gameObject.SetActive(false);
        }
    }
}
