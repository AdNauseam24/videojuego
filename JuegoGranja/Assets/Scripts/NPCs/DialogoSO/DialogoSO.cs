using UnityEngine;

[CreateAssetMenu(fileName = "DialogoSO", menuName = "Diálogo/NodoDiálogo")]
public class DialogoSO : ScriptableObject
{
    public LineaDialogo[] lineas;
}

[System.Serializable]
public class LineaDialogo
{
    public ActorSO speaker;
    [TextArea(3,5)]public string texto;
}