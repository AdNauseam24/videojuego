using UnityEngine;

[CreateAssetMenu(fileName = "ActorSO", menuName = "Diálogo/NPC")]
public class ActorSO : ScriptableObject
{
    public string nombreActor;
    public Sprite retrato;

    public bool habladoHoy;
    public int nivelRelacion;

    public int[] regalosFavoritos;
    public int[] regalosDesagradables;

    public DialogoSO dialogoNivel1;
    public DialogoSO dialogoNivel2;
    public DialogoSO dialogoNivel3;

    public DialogoSO dialogoAgrado;
    public DialogoSO dialogoNeutro;
    public DialogoSO dialogoDesagrado;

    public bool aplicable;
}
