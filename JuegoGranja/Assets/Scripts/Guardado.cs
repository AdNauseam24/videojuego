using UnityEngine;
using System.IO;

public class Guardado
{
    private static SaveData _saveData = new SaveData();


    [System.Serializable]
    public struct SaveData
    {
        public StatsSavedata statsData;
        public InventorySaveData inventoryData;
        public DialogueTrackerSaveData dialogueData;
        public SueloSaveData sueloData;
    }

    public static string SaveFileName()
    {
        string saveFile = Application.persistentDataPath + "/save" + ".save";
        return saveFile;
    }

    public static void Save()
    {
        HandleSaveData();

        File.WriteAllText(SaveFileName(), JsonUtility.ToJson(_saveData, true));
    }

    private static void HandleSaveData()
    {
        StatsGenerales.Instance.Save(ref _saveData.statsData);
        GestorInventario.Instance.Save(ref _saveData.inventoryData);
        DialogueHistoryTracker.Instance.Save(ref _saveData.dialogueData);
        Suelo.Instance.Save(ref _saveData.sueloData);
    }

    public static void Load()
    {
        string saveContent = File.ReadAllText(SaveFileName());

        _saveData = JsonUtility.FromJson<SaveData>(saveContent);
        HandleLoadData();
    }
    private static void HandleLoadData()
    {
        StatsGenerales.Instance.Load(_saveData.statsData);
        GestorInventario.Instance.Load(_saveData.inventoryData);
        DialogueHistoryTracker.Instance.Load(_saveData.dialogueData);
        Suelo.Instance.Load(_saveData.sueloData);
    }
}
