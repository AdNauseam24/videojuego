using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueHistoryTracker : MonoBehaviour
{
 public static DialogueHistoryTracker Instance;
 private readonly List<ActorSO> spokenNPCs = new List<ActorSO>();
 public ActorSO[] personajesRelacionables;

 public HashSet<string> escenasPendientes = new HashSet<string>();

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void RegistrarNPC(ActorSO actorSO)
    {
        spokenNPCs.Add(actorSO);
    }

    public bool HabladoCon(ActorSO actorSO)
    {
        return spokenNPCs.Contains(actorSO);
    }

    public void LImpiarLista()
    {
        spokenNPCs.Clear();
    }

    public void CambioDia()
    {
        foreach (var npc in spokenNPCs)
        {
            npc.habladoHoy = false;
        }
    }

    public void Save(ref DialogueTrackerSaveData data)
    {
        data.spokenNPCs = spokenNPCs.ToArray();
        data.escenasPendientes = escenasPendientes.ToArray();

        List<ActorSOSaveData> actorSaveList = new List<ActorSOSaveData>();
        foreach (var actor in personajesRelacionables)
        {
            ActorSOSaveData actorSOSaveData = new ActorSOSaveData
            {
                nivelRelacion = actor.nivelRelacion
            };
            actorSaveList.Add(actorSOSaveData);
        }
        data.actorSOSaveDatas = actorSaveList.ToArray();
    }
    public void Load(DialogueTrackerSaveData data)
    {
        ActorSO [] NPCs = data.spokenNPCs;
        spokenNPCs.AddRange(NPCs);

        string[] escenas = data.escenasPendientes;
        escenasPendientes.AddRange(escenas);

         ActorSOSaveData[] actorArray = data.actorSOSaveDatas;
        for (int i = 0; i < actorArray.Length; i++)
        {
            personajesRelacionables[i].nivelRelacion = actorArray[i].nivelRelacion;
        }
    }
}

[System.Serializable]
public struct DialogueTrackerSaveData
{
    public ActorSO[] spokenNPCs;
    public ActorSOSaveData[] actorSOSaveDatas;

    public string[] escenasPendientes;
}

[System.Serializable]
public struct ActorSOSaveData
{
    public int nivelRelacion;
}


