using UnityEditor;
using UnityEngine;

public class ArbolesAlternativos : MonoBehaviour
{
    [SerializeField]
    private float vida;

    [SerializeField]
    private GameObject canvas;

    [SerializeField]
    private SliderScript slider;

    public Animator animator;

    private float danio;

    public int indice;
    private bool activo = true;
    void Start()
    {
        vida = Random.Range(8,12);
        Vector2 vector =  transform.position;
        canvas.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 0.7f);
    }

    // Update is called once per frame
    void Update()
    {
        if(vida <= 0)
        {
            Caer();
        }
    }

    public void Caer()
    {
        activo = false;
        animator.SetBool("activar",true);
    }

    public void Romperse()
    {
        Object prefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/ObjetoDrop.prefab", typeof(ObjetoDrop));
		ObjetoDrop drop = Instantiate(prefab,GameObject.FindGameObjectWithTag("ObjetosMapa").transform, true) as ObjetoDrop;

        drop.transform.position = transform.position;
		drop.SetCantidad(Random.Range(1,3));
		drop.SetId(9);
		drop.GetComponent<ObjetoDrop>().enabled = true;

        StatsGenerales.Instance.arbolesTalados[indice] = true;
        Destroy(gameObject);
    }

    public void ActivarMinijuego()
    {
        danio = StatsGenerales.Instance.danioArboles;
        canvas.SetActive(true);
        slider.Activar();
    }
    public void RecibirDaño()
    {
        vida -= danio*slider.DevolverMultiplicador();
    }

    public float GetVida()
    {
        return vida;
    }
    public void desactivarCanvas()
    {
        canvas.SetActive(false);
    }

    public bool GetActivo()
    {
        return activo;
    }
}
