using UnityEditor;
using UnityEngine;

public class Rocas : MonoBehaviour
{
    [SerializeField]
    private float vida;

    [SerializeField]
    private Canvas canvas;
    void Start()
    {
        vida = Random.Range(8,12);
        Vector2 vector =  transform.position;
        canvas.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 0.7f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Romperse()
    {
        Object prefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/ObjetoDrop.prefab", typeof(ObjetoDrop));
		ObjetoDrop drop = Instantiate(prefab,GameObject.FindGameObjectWithTag("ObjetosMapa").transform, true) as ObjetoDrop;

        drop.transform.position = transform.position;
		drop.SetCantidad(Random.Range(1,3));
		drop.SetId(8);
		drop.GetComponent<ObjetoDrop>().enabled = true;

        Destroy(gameObject);
    }

    public float GetVida()
    {
        return vida;
    }
}
