using UnityEngine;

[CreateAssetMenu(fileName = "DialogoSO", menuName = "Diálogo/NodoDiálogo")]
public class DialogoSO : ScriptableObject
{
    public LineaDialogo[] lineas;
    public OpcionesDialogo[] opciones;
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