using TMPro;
using UnityEngine;

public class StatsGenerales : MonoBehaviour
{
    public static StatsGenerales Instance;
    public int oro = 100;
    public float danioRocas = 3.5f;
    public float danioArboles = 3.5f;
    public float vPesca= 6f;
    public float vPerderPez = 6f;

    public TMP_Text textoOro;



   private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        UpdateOro();
    }

    public void SumarOro(int n)
    {
        oro+=n;
        UpdateOro();
    }

     public void RestarOro(int n)
    {
        oro-=n;
        UpdateOro();
    }

    private void UpdateOro()
    {
        textoOro.text = oro.ToString();
    }

}
