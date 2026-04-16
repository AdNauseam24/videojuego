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

    public string escenaNivel1;
    public string escenaNivel2;
    public string escenaNivel3;

    public DialogoSO dialogoAgrado;
    public DialogoSO dialogoNeutro;
    public DialogoSO dialogoDesagrado;

    public bool aplicable;
}
