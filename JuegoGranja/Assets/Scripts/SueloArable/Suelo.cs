using UnityEngine;

public class Suelo : MonoBehaviour
{
    [SerializeField]
    private GameObject[] tilesSuelo;

    public void OcultarTiles()
    {
        foreach(GameObject tile in tilesSuelo)
        {
            tile.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    public void MostrarTiles()
    {
        foreach(GameObject tile in tilesSuelo)
        {
            tile.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
