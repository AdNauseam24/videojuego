using UnityEngine;

public class RegistroAyuda : MonoBehaviour
{
  public static RegistroAyuda Instance;
  //1 humanos, 2 vampiros, 0 default
  public int ayuda;

    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
