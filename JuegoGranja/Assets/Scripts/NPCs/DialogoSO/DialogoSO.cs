using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogoSO", menuName = "Diálogo/NodoDiálogo")]
public class DialogoSO : ScriptableObject
{
    public LineaDialogo[] lineas;
    public OpcionesDialogo[] opciones;

    [Header("Requisitos condicionales(opcional)")]
    public ActorSO[] requisitoNPCs;

    public int afinidadPueblo1;

    public int afinidadPueblo2;

    public int capituloHistoria;

    [Header("ControlFlags")]
    public bool removeAfterPlay;
    public List<DialogoSO> removeListAfterPlay;


    public bool condicionCumplida()
    {
        if(requisitoNPCs.Length > 0)
        {
            foreach (var npc in requisitoNPCs)
            {
                if (!DialogueHistoryTracker.Instance.HabladoCon(npc))
                {
                    return false;
                }
            }
        }
        if(afinidadPueblo1 != 0 && afinidadPueblo1 > StatsGenerales.Instance.afinidadPueblo1)
        {
            return false;
        }
        if(afinidadPueblo2 != 0 && afinidadPueblo2 > StatsGenerales.Instance.afinidadPueblo2)
        {
            return false;
        }
        if(capituloHistoria > StatsGenerales.Instance.capituloHistoria)
        {
            return false;
        }


        return true;
    }
}

[System.Serializable]
public class LineaDialogo
{
    public ActorSO speaker;
    [TextArea(3,5)]public string texto;
}

[System.Serializable]
public class OpcionesDialogo
{
    public string textoOpcion;
    public DialogoSO nextDialogo;
}