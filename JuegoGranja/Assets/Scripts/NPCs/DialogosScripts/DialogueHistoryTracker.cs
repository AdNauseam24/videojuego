using System.Collections.Generic;
using UnityEngine;

public class DialogueHistoryTracker : MonoBehaviour
{
 public static DialogueHistoryTracker Instance;
 private readonly List<ActorSO> spokenNPCs = new List<ActorSO>();

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
        Debug.Log(actorSO.nombreActor);
    }

    public bool HabladoCon(ActorSO actorSO)
    {
        return spokenNPCs.Contains(actorSO);
    }

    public void LImpiarLista()
    {
        spokenNPCs.Clear();
    }
}
