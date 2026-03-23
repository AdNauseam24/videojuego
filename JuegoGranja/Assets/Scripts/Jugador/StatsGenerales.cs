using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class StatsGenerales : MonoBehaviour
{
    public static StatsGenerales Instance;
    public int oro = 100;
    public float danioRocas = 2.5f;
    public float danioArboles = 2.5f;

    public int capituloHistoria;

    
    public int afinidadPueblo1 = 0;
    public int afinidadPueblo2 = 0;

    public int ultimaAfinidad;

    //A mayor número más lento
    public float vPesca= 6f;
    public float vPerderPez = 6f;

    //Hacha-Pico-Caña
    public int[] mejorasHerramientas = {0,0,0};

    public TMP_Text textoOro;

    public bool[] arbolesTalados = {false,false};
    public bool[] rocasPicadas = {false,false};

    public bool puentePueblo1;
    public bool PuentePueblo2;

    public bool vallaPueblo1;
    public bool vallaPueblo2;

    public bool playaDesbloqueada;

     public string[] requisitosMisiones= new string[]
    {
        "50 100 9", 
        "75 100 8"
    };

    public bool entregado;

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
        requisitosMisiones = new string[]
        {
        "50 100 9", 
        "75 100 8",
        "300 50 23"
    };
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

    public void Save(ref StatsSavedata data)
    {
        data.capituloHistoria = capituloHistoria;
        data.oro = oro;
        data.danioRocas = danioRocas;
        data.danioArboles = danioArboles;
        data.afinidadPueblo1 = afinidadPueblo1;
        data.afinidadPueblo2 = afinidadPueblo2;
        data.ultimaAfinidad = ultimaAfinidad;
        data.vPesca = vPesca;
        data.vPerderPez = vPerderPez;
        data.mejorasHerramientas = mejorasHerramientas;
        data.arbolesTalados = arbolesTalados;
        data.rocasPicadas = rocasPicadas;
        data.puentePueblo1 = puentePueblo1;
        data.puentePueblo2 = PuentePueblo2;
        data.vallaPueblo1 = vallaPueblo1;
        data.vallaPueblo2 = vallaPueblo2;
        data.playaDesbloqueada = playaDesbloqueada;
        data.entregado = entregado;
    }
    public void Load(StatsSavedata data)
    {
        capituloHistoria = data.capituloHistoria;
        oro = data.oro;
        UpdateOro();

        danioRocas = data.danioRocas;
        danioArboles = data.danioArboles;
        afinidadPueblo1 = data.afinidadPueblo1;
        afinidadPueblo2 = data.afinidadPueblo2;
        ultimaAfinidad = data.ultimaAfinidad;
        vPesca = data.vPesca;
        vPerderPez = data.vPerderPez;
        mejorasHerramientas = data.mejorasHerramientas;
        arbolesTalados = data.arbolesTalados;
        rocasPicadas = data.rocasPicadas;
        puentePueblo1 = data.puentePueblo1;
        PuentePueblo2 = data.puentePueblo2;
        vallaPueblo1 = data.vallaPueblo1;
        vallaPueblo2 = data.vallaPueblo2;
        playaDesbloqueada = data.playaDesbloqueada;
        entregado = data.entregado;

    }

    void Update()
    {
        if (Keyboard.current.numpad0Key.wasPressedThisFrame)
        {
            Guardado.Save();
            Debug.Log("guardado");
        }
        if (Keyboard.current.numpad1Key.wasPressedThisFrame)
        {
            Guardado.Load();
            Debug.Log("Cargado");
        }
    }

}
[System.Serializable]
public struct StatsSavedata
{
    public int capituloHistoria;
    public int oro;
    public float danioRocas;
    public float danioArboles;
    public int afinidadPueblo1;
    public int afinidadPueblo2;
    public int ultimaAfinidad;
    public float vPesca;
    public float vPerderPez;
    public int[] mejorasHerramientas;
    public bool[] arbolesTalados;
    public bool [] rocasPicadas;
    public bool puentePueblo1;
    public bool puentePueblo2;
    public bool vallaPueblo1;
    public bool vallaPueblo2;
    public bool playaDesbloqueada;
    public bool entregado;
}
