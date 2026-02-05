using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GestorMejoras : MonoBehaviour
{
    private string[,] listaMejoras= new string[,]
    {
    {"100 50 piedra", "200 50 cobre", "300 50 hierro", "400 50 oro"},
    {"100 50 madera", "200 100 madera", "250 50 oro", "300 200 madera"},
    {"100 75 madera", "200 150 madera", "300 75 hierro", "400 75 oro"}
    };

    public TMP_Text[] preciosOro;
    public TMP_Text[] preciosOtroMaterial;
    public Image[] iconosMaterial;
    public Sprite[] sprites;

    public Image[] mejorasAlMax;

    public CanvasGroup mejoraRealizada;
    public CanvasGroup materialesInsuficientes;


    private void UpdateUi()
    {
        bool []flagsMaxMejora = new bool[3];

        for (int i = 0; i < 3; i++)
        {
            if(StatsGenerales.Instance.mejorasHerramientas[i] < 4)
            {
                listaMejoras[i,0] = listaMejoras[i,StatsGenerales.Instance.mejorasHerramientas[i]];
            }
            else
            {
                flagsMaxMejora[i] = true;
            }
        }

        for (int i = 0; i < 3; i++)
        {
            if(flagsMaxMejora[i] == false)
            {
            string[] mejoras = listaMejoras[i,0].Split(" ");
            preciosOro[i].text = mejoras[0];
            preciosOtroMaterial[i].text = mejoras[1];
            iconosMaterial[i].sprite = DevolverIcono(mejoras[2]);
            }
            else
            {
                mejorasAlMax[i].gameObject.SetActive(true);
            }
        }
    }

    public void MejorarHacha()
    {
        if (IntentarMejorar(listaMejoras[0, StatsGenerales.Instance.mejorasHerramientas[0]]))
        {
            StatsGenerales.Instance.mejorasHerramientas[0] +=1;
            StatsGenerales.Instance.danioArboles +=1;
            UpdateUi();
            StopAllCoroutines();
            materialesInsuficientes.alpha = 0;
            StartCoroutine(MostrarObjetoNoDisponible(mejoraRealizada));
        }
        else
        {
            StopAllCoroutines();
            mejoraRealizada.alpha = 0;
            StartCoroutine(MostrarObjetoNoDisponible(materialesInsuficientes));
        }
    }
     public void MejorarPico()
    {
        if (IntentarMejorar(listaMejoras[1, StatsGenerales.Instance.mejorasHerramientas[1]]))
        {
            StatsGenerales.Instance.mejorasHerramientas[1] +=1;
            StatsGenerales.Instance.danioRocas += 1;
            UpdateUi();
            StopAllCoroutines();
            materialesInsuficientes.alpha = 0;
            StartCoroutine(MostrarObjetoNoDisponible(mejoraRealizada));
        }
        else
        {
            StopAllCoroutines();
            mejoraRealizada.alpha = 0;
            StartCoroutine(MostrarObjetoNoDisponible(materialesInsuficientes));
        }
    }
     public void MejorarCania()
    {
        if (IntentarMejorar(listaMejoras[2, StatsGenerales.Instance.mejorasHerramientas[2]]))
        {
            StatsGenerales.Instance.mejorasHerramientas[2] +=1;
            StatsGenerales.Instance.vPerderPez += 1;
            UpdateUi();
            StopAllCoroutines();
            materialesInsuficientes.alpha = 0;
            StartCoroutine(MostrarObjetoNoDisponible(mejoraRealizada));
        }
        else
        {
            StopAllCoroutines();
            mejoraRealizada.alpha = 0;
            StartCoroutine(MostrarObjetoNoDisponible(materialesInsuficientes));
        }
    }

    private bool IntentarMejorar(string mejoras)
    {
        string [] lista = mejoras.Split(" ");
        int materialId = 0;
        switch (lista[2])
        {
            case "madera":
                materialId = 9;
                break;
            case "piedra":
                materialId = 8;
                break;
            case "cobre":
                 materialId = 11;
                break;
            case "hierro":
                materialId = 12;
                break;
            case "oro":
                 materialId = 13;
                break;
            default:
                 materialId = 0;
                break;
        }
        if(StatsGenerales.Instance.oro >= int.Parse(lista[0]) && GestorInventario.Instance.CheckCantidad(materialId, int.Parse(lista[1])))
        {
            StatsGenerales.Instance.RestarOro(int.Parse(lista[0]));
            GestorInventario.Instance.RestarCantidad(materialId, int.Parse(lista[1]));
            return true;
        }

        return false;

    }

    private Sprite DevolverIcono(string nombre)
    {
        switch (nombre)
        {
            case "madera":
                return sprites[0];
            case "piedra":
                return sprites[1];
            case "cobre":
                return sprites[2];
            case "hierro":
                return sprites[3];
            case "oro":
                return sprites[4];
            default:
                return sprites[0];
        }
    }
   


    void Start()
    {
        UpdateUi();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator MostrarObjetoNoDisponible(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 1;
        float startTime = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup-startTime < 1)
        {
        yield return null;
        }
       
       for (int i = 0; i < 5; i++)
        {
            canvasGroup.alpha -= 0.2f;
            startTime = Time.realtimeSinceStartup;
            while (Time.realtimeSinceStartup-startTime < .05f)
            {
                yield return null;
            }
        }
    
    }
}
