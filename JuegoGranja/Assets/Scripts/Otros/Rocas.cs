using UnityEditor;
using UnityEngine;

public class Rocas : MonoBehaviour
{
    [SerializeField]
    private float vida;

    [SerializeField]
    private GameObject canvas;

    [SerializeField]
    private SliderScript slider;

    [SerializeField]
    private TipoRoca tipoRoca;

    private int dropId;
    private int spriteRow;

    private bool cambio1, cambio2;

    public ArraySprites arraySprites;

    void Start()
    {
        vida = Random.Range(11,15);
        Vector2 vector =  transform.position;
        canvas.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 0.7f);
        switch (tipoRoca)
        {
            case TipoRoca.Piedra:
                spriteRow = 0;
                dropId = 8;
                break;
            case TipoRoca.Cobre:
                spriteRow = 1;
                dropId = 11;
                break;
            case TipoRoca.Hierro:
                spriteRow = 2;
                dropId = 12;
                break;
            case TipoRoca.Oro:
                spriteRow = 3;
                dropId = 13;
                break;
        }
        GetComponent<SpriteRenderer>().sprite = arraySprites.filas[spriteRow].fila[0];
    }

    void Update()
    {

        if(!cambio1 && vida <= 10)
        {
            cambio1 = true;
            GetComponent<SpriteRenderer>().sprite = arraySprites.filas[spriteRow].fila[1];

        }
         if(!cambio2 && vida <= 5)
        {
            cambio1 = true;
            GetComponent<SpriteRenderer>().sprite = arraySprites.filas[spriteRow].fila[2];

        }

        if(vida <= 0)
        {
            Romperse();
        }
    }

    public void Romperse()
    {
        Object prefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/ObjetoDrop.prefab", typeof(ObjetoDrop));
		ObjetoDrop drop = Instantiate(prefab,GameObject.FindGameObjectWithTag("ObjetosMapa").transform, true) as ObjetoDrop;

        drop.transform.position = transform.position;
		drop.SetCantidad(Random.Range(1,3));
		drop.SetId(dropId);
		drop.GetComponent<ObjetoDrop>().enabled = true;

        Destroy(gameObject);
    }

    public void ActivarMinijuego()
    {
        canvas.SetActive(true);
        slider.Activar();
    }
    public void RecibirDaño()
    {
        vida -= 3.5f*slider.DevolverMultiplicador();
    }

    public float GetVida()
    {
        return vida;
    }
    public void desactivarCanvas()
    {
        canvas.SetActive(false);
    }
    
}

public enum TipoRoca
{
    Piedra,Cobre,Hierro,Oro
}

 [System.Serializable]
public class ArraySprites
{
    [System.Serializable]
    public struct rowData
    {
        public Sprite [] fila;

    }

    public rowData[] filas = new rowData[5];
}
