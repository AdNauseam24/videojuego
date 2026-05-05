using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Guardado;

public class MenuPrincipal : MonoBehaviour
{
    public SlotGuardado slotBorrar;
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

    public AudioSource sfxAudio;
    public AudioClip clickMenu;
    public SlotGuardado[] slots;

   public Canvas botonesPrincipales;
   public Canvas menuSlots;
   public Canvas IntroducirNombre;
   public Canvas borrarPartida;
   public string nombre;

   public TMP_Text banner1;
   public TMP_Text banner2;
   public TMP_Text banner3;

   public bool modoCargar;

   public void ModoCargar()
    {
        sfxAudio.PlayOneShot(clickMenu);
        botonesPrincipales.gameObject.SetActive(false);
        modoCargar = true;
        ModificarSlots();
        menuSlots.gameObject.SetActive(true);
    }
    public void NuevaPartida()
    {
        sfxAudio.PlayOneShot(clickMenu);
        botonesPrincipales.gameObject.SetActive(false);
        modoCargar = false;
        ModificarSlots();
        menuSlots.gameObject.SetActive(true);
    }

    public void CerrarSlots()
    {
        sfxAudio.PlayOneShot(clickMenu);
        botonesPrincipales.gameObject.SetActive(true);
        menuSlots.gameObject.SetActive(false);
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
        sfxAudio.PlayOneShot(clickMenu);
        IntroducirNombre.gameObject.SetActive(true);
    }
    public void DesactivarInputField()
    {
        sfxAudio.PlayOneShot(clickMenu);
        IntroducirNombre.gameObject.SetActive(false);
    }

    public void RecogerNombre(string input)
    {
        if(!input.Equals("") && Input.GetKeyDown(KeyCode.Return) && input.Length < 15 && !input.Equals(banner1.text) && !input.Equals(banner2.text) && !input.Equals(banner3.text))
        {
        nombreArchivo = input;
        SceneManager.LoadScene("Capitulo1-1");
        }
    }

    public void CerrarBorrado()
    {
        sfxAudio.PlayOneShot(clickMenu);
        borrarPartida.gameObject.SetActive(false);
    }

    public void BorrarGuardado()
    {
        sfxAudio.PlayOneShot(clickMenu);
        Debug.Log(Application.persistentDataPath + "/" + slotBorrar.nombre.text + ".save");
        File.Delete(Application.persistentDataPath + "/" + slotBorrar.nombre.text + ".save");
        CerrarBorrado();
        slotBorrar.VaciarSlot();
    }

    public void CerrarJuego()
    {
        sfxAudio.PlayOneShot(clickMenu);
        #if UNITY_STANDALONE
        Application.Quit();
        #endif
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
