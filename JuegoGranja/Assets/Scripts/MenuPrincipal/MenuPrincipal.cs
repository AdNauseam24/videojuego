using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Guardado;

public class MenuPrincipal : MonoBehaviour
{
    private static SaveData saveData = new SaveData();
    public static MenuPrincipal Instance;
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
   public SlotGuardado[] slots;

   public Canvas botonesPrincipales;
   public Canvas menuSlots;
   public Canvas IntroducirNombre;
   public string nombre;

   public bool modoCargar;

   public void ModoCargar()
    {
        botonesPrincipales.gameObject.SetActive(false);
        modoCargar = true;
        ModificarSlots();
        menuSlots.gameObject.SetActive(true);
    }
    public void NuevaPartida()
    {
        botonesPrincipales.gameObject.SetActive(false);
        modoCargar = false;
        ModificarSlots();
        menuSlots.gameObject.SetActive(true);
    }

    public void ModificarSlots()
    {
        string[] saveFiles = Directory.GetFiles(Application.persistentDataPath, "*.save");

        for (int i = 0; i < saveFiles.Length; i++)
        {
            saveFiles[i] = Path.GetFileName(saveFiles[i]);
            string saveContent = File.ReadAllText(Application.persistentDataPath + "/" + saveFiles[i]);
            saveData = JsonUtility.FromJson<SaveData>(saveContent);
            string nombre = saveFiles[i].Split(".")[0];
            int dia = saveData.statsData.dia;
            int oro = saveData.statsData.oro;

            slots[i].ModificarSlot(nombre,dia,oro);

        }
        
    }

    public void ActivarInputField()
    {
        IntroducirNombre.gameObject.SetActive(true);
    }

    public void RecogerNombre(string input)
    {
        nombreArchivo = input;
        SceneManager.LoadScene("Capitulo1-1");
    }
}
