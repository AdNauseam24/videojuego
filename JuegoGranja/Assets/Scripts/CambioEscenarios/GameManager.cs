using UnityEngine;

public class GameManager : MonoBehaviour
{
  public static GameManager Instance;

[Header("ObjetosPersistentes")]
public GameObject[] objetosPersistentes;

    void Awake()
    {
        if(Instance != null)
        {
            LimpiezaDuplicados();
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            MarkPersistentObjects();
        }
    }

    private void MarkPersistentObjects()
    {
        foreach (GameObject obj in objetosPersistentes)
        {
            if(obj != null)
            {
                DontDestroyOnLoad(obj);
            }
        }
    }
    private void LimpiezaDuplicados()
    {
        foreach (GameObject obj in objetosPersistentes)
        {
            Destroy(obj);
        }
        Destroy(gameObject);
    }
}
