using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MenuNotas : MonoBehaviour
{
    public static MenuNotas Instance;

    public Image inputFieldImage;
    public Image panelNotas;
    private CanvasGroup notasCanvas;
    public TMP_InputField inputField;
    public List<Note> notas = new List<Note>();

    private bool abierto;

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
    void Start()
    {
        inputFieldImage.gameObject.SetActive(false);
        notasCanvas = panelNotas.GetComponent<CanvasGroup>();

        notasCanvas.alpha = 0;
        notasCanvas.blocksRaycasts = false;
        notasCanvas.interactable = false;
    }

    public void CerrarMenu()
    {
        notasCanvas.alpha = 0;
        notasCanvas.blocksRaycasts = false;
        notasCanvas.interactable = false;

        GameObject.FindGameObjectWithTag("Fade").GetComponent<CanvasGroup>().alpha = 0f;

        abierto = false;

        Time.timeScale = 1;
    }

    public void ClickBotonMenu()
    {
        if(!abierto && Time.timeScale == 1)
        {
            AbrirMenu();
        }
        else if(abierto && Time.timeScale == 0)
        {
            CerrarMenu();
        }
    }

    private void AbrirMenu()
    {
        notasCanvas.alpha = 1;
        notasCanvas.blocksRaycasts = true;
        notasCanvas.interactable = true;

        GameObject.FindGameObjectWithTag("Fade").GetComponent<CanvasGroup>().alpha = 0.8f;

        abierto = true;

        Time.timeScale = 0;
    }

    public void AbrirInputField()
    {
        inputFieldImage.gameObject.SetActive(true);
    }

    public void NuevaNota()
    {
        if(!inputField.text.Equals(""))
        {
            Object prefab;
                #if UNITY_EDITOR

                    prefab = AssetDatabase.LoadAssetAtPath("Assets/Resources/Prefabs/Nota.prefab", typeof(Image));

                #endif

                #if UNITY_STANDALONE

                    prefab = Resources.Load("Prefabs/Nota", typeof(Image));

                #endif

            Image tarea = Instantiate(prefab,GameObject.FindGameObjectWithTag("Notas").transform, false) as Image;

            tarea.GetComponent<Note>().texto = inputField.text;
            tarea.GetComponent<Note>().completada = false;

            tarea.GetComponentInChildren<TMP_Text>().text = inputField.text;
            tarea.GetComponentInChildren<Toggle>().isOn = false;

            notas.Add(tarea.GetComponent<Note>());

            inputField.text = "";
            inputFieldImage.gameObject.SetActive(false);
        }

    }

    private void NuevaNota(NoteSaveData note)
    {

        Object prefab;
            #if UNITY_EDITOR

                prefab = AssetDatabase.LoadAssetAtPath("Assets/Resources/Prefabs/Nota.prefab", typeof(Image));

            #endif

            #if UNITY_STANDALONE

                prefab = Resources.Load("Prefabs/Nota", typeof(Image));

            #endif

            Image tarea = Instantiate(prefab,GameObject.FindGameObjectWithTag("Notas").transform, false) as Image;

            tarea.GetComponentInChildren<TMP_Text>().text = note.text;
            tarea.GetComponentInChildren<Toggle>().isOn = note.completado;

            tarea.GetComponent<Note>().texto = note.text;
            tarea.GetComponent<Note>().completada = note.completado;

        if (tarea.GetComponent<Note>().completada)
        {
             tarea.GetComponent<Note>().SetTrue();
        }
            notas.Add(tarea.GetComponent<Note>());
            

    }

    public void Save(ref MenuNoteSaveData data)
    {
      List<NoteSaveData> noteSaveList = new List<NoteSaveData>();   

        foreach (var nota in notas)
        {
            NoteSaveData noteSaveData= new NoteSaveData
            {
                text = nota.texto,
                completado = nota.completada
            };
            noteSaveList.Add(noteSaveData);
        }
        data.notes = noteSaveList.ToArray();

    }
    public void Load(MenuNoteSaveData data)
    {
         NoteSaveData[] noteArray = data.notes;
        for (int i = 0; i < noteArray.Length; i++)
        {
            NuevaNota(noteArray[i]);
        }
    }

}

[System.Serializable]
public struct MenuNoteSaveData
{
    public NoteSaveData[] notes;
}

[System.Serializable]
public struct NoteSaveData
{
    public string text;
    public bool completado;
}

