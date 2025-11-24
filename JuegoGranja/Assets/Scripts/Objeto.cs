using System;
using System.Collections;
using UnityEngine;
using static TipoObjetoEnum;

public class Objeto : MonoBehaviour
{
    //para poder cambiar el nombre desde el editor de Unity
    [SerializeField]
    protected string nombre;
   
     [SerializeField]
    protected Sprite sprite;

    [SerializeField]
    protected int id;

    [SerializeField]
    protected TipoObjeto tipoObjeto;

    protected GestorInventario gestorInventario;
    void Start()
    {
        //buscar el gameobject inventario y acceder al componente del gestor
        gestorInventario = GameObject.Find("Inventario").GetComponent<GestorInventario>();
    }

    public void UsarMapa(Vector2 posicion)
    {
        switch (this.id)
        {
            case 2:
                CoroutineWithData cd = new CoroutineWithData(this, UsarPico(posicion));
                break;
                
                

        }
        
    }

    IEnumerator UsarPico(Vector2 posicion)
    {
        if(Physics2D.OverlapCircle(posicion, .2f, LayerMask.GetMask("Piedras")))
        {
            RaycastHit2D hit = Physics2D.Raycast(posicion,new Vector2(1,1), 0.3f, LayerMask.GetMask("Piedras"));
            Rocas roca = hit.transform.gameObject.GetComponent<Rocas>();
            Time.timeScale = 0;
            roca.ActivarMinijuego();
            yield return new WaitForSecondsRealtime(1f);
            roca.desactivarCanvas();
            roca.RecibirDaño();

            Time.timeScale = 1;
            
           yield return 1;
        }
       yield return -1;
    }
    private void UsarHacha(Vector2 psoicion)
    {
        
    }

    public string GetNombre()
    {
        return nombre;
    }
    public Sprite GetSprite()
    {
        return sprite;
    }

    public int GetTipoObjeto()
    {
        return (int)tipoObjeto;
    }

    public class CoroutineWithData {
    public Coroutine coroutine { get; private set; }
    public object result;
    private IEnumerator target;

    public CoroutineWithData(MonoBehaviour owner, IEnumerator target) {
	    this.target = target;
	    this.coroutine = owner.StartCoroutine(Run());
    }

	private IEnumerator Run() {
        while(target.MoveNext()) {
            result = target.Current;
            yield return result;
        }
    }
}
}
