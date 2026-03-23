using System.Collections.Generic;
using UnityEngine;

public class Suelo : MonoBehaviour
{
    [SerializeField]
    private SueloArable[] tilesSuelo;

    public static Suelo Instance;

     void Awake()
    {
         if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    public void OcultarTiles()
    {
        foreach(var tile in tilesSuelo)
        {
            tile.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    public void MostrarTiles()
    {
        foreach(var tile in tilesSuelo)
        {
            tile.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    public void Save(ref SueloSaveData data)
    {
        List<GridSaveData> gridSaveList = new List<GridSaveData>();

        foreach(var tile in tilesSuelo)
        {
            GridSaveData gridSaveData = new GridSaveData
            {
                arado = tile.arado,
                regado = tile.regado,
                plantado = tile.plantado,
                crecido = tile.crecido,
                flagComenzadoCrecimiento = tile.flagComenzadoCrecimiento,
                flagCrecimiento1 = tile.flagCrecimiento1,
                flagListoCosecha = tile.flagListoCosecha,
                tiempoRestante1 = tile.duracion1 - Time.time,
                tiempoRestante2 = tile.duracion2 - Time.time,
                filaSprites = tile.filaSprites,
                idDrop = tile.idDrop
            };
            gridSaveList.Add(gridSaveData);
        }
        data.grids = gridSaveList.ToArray();
    }

    public void Load(SueloSaveData data)
    {
        GridSaveData[] gridArray = data.grids;
        for (int i = 0; i < gridArray.Length; i++)
        {
            tilesSuelo[i].UpdateTile(gridArray[i]);
        }
    }
}

[System.Serializable]
public struct SueloSaveData
{
    public GridSaveData[] grids;
}

[System.Serializable]
public struct GridSaveData
{
    public bool arado,regado,plantado,crecido;
    public bool flagComenzadoCrecimiento, flagCrecimiento1, flagListoCosecha;
    public float tiempoRestante1, tiempoRestante2;
    public int filaSprites, idDrop;
}
