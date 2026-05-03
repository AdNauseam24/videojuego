using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MenuTareas : MonoBehaviour
{
   private string[] tareas;
   private List<TMP_Text> contenido = new List<TMP_Text>();
   private bool abierto;

   public Image panelTareas;
   private CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = panelTareas.GetComponent<CanvasGroup>();
        tareas = new string[]
        {
            "Explora los alrededores",
            "Ayuda a los lugareños a reparar el puente de la mina (100 Madera 50 Oro)",
            "Derrota a la criatura de las minas",
            "Informa haber derrotado a la criatura de las minas",
            "Ayuda a los lugareños a proteger la arboleda (100 Piedra 75 Oro)",
            "Explora el misterio de la arboleda",
            "Informa de tu extraño encuentro",
            "Ayuda a los lugareños a preparar el festival (50 Regalos del Dragón 300 Oro)",
            "Una criatura temible habita las costas, hazle frente",
            "Informa de tu victoria",
            "Disfruta el juego como más te guste :)"
        };

        Debug.Log(StatsGenerales.Instance.contadorTareas);
        AnadirTarea();

        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

    }


    public void ActualizarLista(int n)
    {
        StatsGenerales.Instance.contadorTareas = n;
        AnadirTarea();
    }

    private void AnadirTarea()
    {
        foreach (var tarea in contenido)
        {
            Destroy(tarea);
        }
        contenido.Clear();

        for (int i = StatsGenerales.Instance.contadorTareas; i >= 0; i--)
        {
            Object prefab;
            #if UNITY_EDITOR

                prefab = AssetDatabase.LoadAssetAtPath("Assets/Resources/Prefabs/TextoTareas.prefab", typeof(TMP_Text));

            #endif

            #if UNITY_STANDALONE

                prefab = Resources.Load("Prefabs/TextoTareas", typeof(TMP_Text));

            #endif

            TMP_Text tarea = Instantiate(prefab,GameObject.FindGameObjectWithTag("Tareas").transform, false) as TMP_Text;

            tarea.text = tareas[i];
            tarea.fontStyle = FontStyles.Bold;
            if(i != StatsGenerales.Instance.contadorTareas)
            {
                tarea.fontStyle = FontStyles.Strikethrough | FontStyles.Bold;
            }

            contenido.Add(tarea);
        }
    }

    private void AbrirTareas()
    {
        if(!abierto && Time.timeScale == 1)
        {
            Time.timeScale = 0;
            abierto = true;

            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;            

            GameObject.FindGameObjectWithTag("Fade").GetComponent<CanvasGroup>().alpha = 0.8f;
        }
    }
    private void CerrarTareas()
    {
        if(abierto && Time.timeScale == 0)
        {
            Time.timeScale = 1;
            abierto = false;
            
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
             GameObject.FindGameObjectWithTag("Fade").GetComponent<CanvasGroup>().alpha = 0f;
        }
    }

    public void ClickBoton()
    {
        if(!abierto && Time.timeScale == 1)
        {
            AbrirTareas();
        }
        else
        {
            CerrarTareas();
        }
    }
}
