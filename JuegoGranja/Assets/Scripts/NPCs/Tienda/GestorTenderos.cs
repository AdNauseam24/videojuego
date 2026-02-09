using UnityEngine;

public class GestorTenderos : MonoBehaviour
{
   public static GestorTenderos Instance;
   [SerializeField] private Tendero[] tenderos;
   [SerializeField] private Tendero[] tenderosPueblo2;

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
        for (int i = 0; i < 4; i++)
        {
            tenderos[i].gameObject.SetActive(true);
        }
    }
      public void DesactivarTenderosPueblo1()
    {
        for (int i = 0; i < 4; i++)
        {
            tenderos[i].gameObject.SetActive(false);
        }
    }
     public void ActivarTenderosPueblo2()
    {
        for (int i = 0; i < 4; i++)
        {
            tenderosPueblo2[i].gameObject.SetActive(true);
        }
    }
      public void DesactivarTenderosPueblo2()
    {
        for (int i = 0; i < 4; i++)
        {
            tenderosPueblo2[i].gameObject.SetActive(false);
        }
    }
}
