using Mono.Cecil.Cil;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class SueloArable : MonoBehaviour
{
    private bool arado,regado,plantado, crecido;

    private bool flagComenzadoCrecimiento, flagCrecimiento1, flagListoCosecha;

    [SerializeField]
    private Sprite[] sprites;

    private float duracion1, duracion2;


    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!flagComenzadoCrecimiento && arado && regado && plantado && !crecido)
        {
            duracion1 = Time.time + 60;
            duracion2 = Time.time + 180;
            flagComenzadoCrecimiento = true;
            
        }

        if(!flagCrecimiento1 && flagComenzadoCrecimiento && Time.time > duracion1)
        {
            flagCrecimiento1 = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[5];
        }
        if(!flagListoCosecha && flagComenzadoCrecimiento && Time.time > duracion2)
        {
            crecido = true;
            flagListoCosecha = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[6];
        }
    }

    public void Arar()
    {
        if((!arado || plantado) && !regado)
        {
           
            flagCrecimiento1 = false;
            flagListoCosecha = false;
            flagComenzadoCrecimiento = false;

            arado = true;
            plantado = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
        }
        else if(plantado && regado && !crecido)
        {
          
            flagCrecimiento1 = false;
            flagListoCosecha = false;
            flagComenzadoCrecimiento = false;

            plantado = false;
            arado = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[3];

        }
    }

    public void Regar()
    {
        if(!regado && !plantado && arado)
        {
            regado = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[3];
        }
        else if(!regado && arado && plantado)
        {
            regado = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[4];
        }
    }

    public int Plantar()
    {
        if(!plantado && arado && !regado)
        {
            plantado = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[2];
            return 1;
        }
        else if (!plantado && arado && regado)
        {
            plantado = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[4];
            return 1;
        }
        return 0;
    }

    public void OnMouseDown()
    {
        
        if(crecido)
		{
			arado = false;
            crecido = false;
            regado = false;
            flagCrecimiento1 = false;
            flagListoCosecha = false;
            flagComenzadoCrecimiento = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];

            Object prefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/ObjetoDrop.prefab", typeof(ObjetoDrop));
            ObjetoDrop drop = Instantiate(prefab,GameObject.FindGameObjectWithTag("ObjetosMapa").transform, true) as ObjetoDrop;

            
            drop.transform.position = transform.position;
            drop.SetCantidad(Random.Range(1,3));
            drop.SetId(10);

            //activamos
            drop.GetComponent<ObjetoDrop>().enabled = true;

		}
    }

   
}
