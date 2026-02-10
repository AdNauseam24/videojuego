using TMPro;
using UnityEngine;

public class StatsGenerales : MonoBehaviour
{
    public static StatsGenerales Instance;
    public int oro = 100;
    public float danioRocas = 2.5f;
    public float danioArboles = 2.5f;

    public int capituloHistoria;

    
    public int afinidadPueblo1 = 0;
    public int afinidadPueblo2 = 0;

    //A mayor número más lento
    public float vPesca= 6f;
    public float vPerderPez = 6f;

    //Hacha-Pico-Caña
    public int[] mejorasHerramientas = {0,0,0};

    public TMP_Text textoOro;

    public bool[] arbolesTalados = {false,false};
    public bool[] rocasPicadas = {false,false};



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
