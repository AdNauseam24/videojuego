using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorTienda : MonoBehaviour
{
    [SerializeField]private List<ObjetosTienda> objetosTienda;
    [SerializeField] private HuecoTienda[] huecosTienda;
    public bool modoVenta;

    public CanvasGroup objetoNoEnElInventario;
    public CanvasGroup oroInsuficiente;
    public CanvasGroup objetoComprado;
    public CanvasGroup objetoVendido;

    private void Start()
    {
        RellenarHuecosTienda();
    }

    public void RellenarHuecosTienda()
    {
        for (int i = 0; i < objetosTienda.Count && i < huecosTienda.Length; i++)
        {
            ObjetosTienda objetoActual = objetosTienda[i];
            huecosTienda[i].Initialize(objetoActual.objeto);
            huecosTienda[i].gameObject.SetActive(true);
        }

        for (int i = objetosTienda.Count; i < huecosTienda.Length; i++)
        {
             huecosTienda[i].gameObject.SetActive(false);
        }
    }

    public void CambiarACompra()
    {
        modoVenta = false;
         for (int i = 0; i < objetosTienda.Count && i < huecosTienda.Length; i++)
        {
            huecosTienda[i].precioTexto.text =  huecosTienda[i].precioCompra.ToString();
        }
    }
     public void CambiarAVenta()
    {
        modoVenta = true;
         for (int i = 0; i < objetosTienda.Count && i < huecosTienda.Length; i++)
        {
            huecosTienda[i].precioTexto.text =  huecosTienda[i].precioVenta.ToString();
        }
    }

    public void IntentarComprar(Objeto objeto)
    {
        if (!modoVenta)
        {
            if(objeto != null && StatsGenerales.Instance.oro >= objeto.precioCompra)
            {
                StatsGenerales.Instance.RestarOro(objeto.precioCompra);
                GestorInventario.Instance.AddItem(objeto.id,objeto.nombre,1,objeto.sprite);
                StopAllCoroutines();
                oroInsuficiente.alpha = 0;
                objetoNoEnElInventario.alpha = 0;
                objetoVendido.alpha = 0;
                StartCoroutine(MostrarObjetoNoDisponible(objetoComprado));
            }
            else
            {
                StopAllCoroutines();
                objetoNoEnElInventario.alpha = 0;
                objetoComprado.alpha = 0;
                objetoVendido.alpha = 0;
                StartCoroutine(MostrarObjetoNoDisponible(oroInsuficiente));
            }
        }
        else
        {
            if (GestorInventario.Instance.VenderObjeto(objeto.id))
            {
                StatsGenerales.Instance.SumarOro(objeto.precioVenta);
                StopAllCoroutines();
                oroInsuficiente.alpha = 0;
                objetoComprado.alpha = 0;
                objetoNoEnElInventario.alpha = 0;
                StartCoroutine(MostrarObjetoNoDisponible(objetoVendido));

            }
            else
            {
                StopAllCoroutines();
                oroInsuficiente.alpha = 0;
                objetoComprado.alpha = 0;
                objetoVendido.alpha = 0;
                StartCoroutine(MostrarObjetoNoDisponible(objetoNoEnElInventario));
            }
        }
       
    }
    public IEnumerator MostrarObjetoNoDisponible(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 1;
        float startTime = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup-startTime < 1)
        {
        yield return null;
        }
       
       for (int i = 0; i < 5; i++)
        {
            canvasGroup.alpha -= 0.2f;
            startTime = Time.realtimeSinceStartup;
            while (Time.realtimeSinceStartup-startTime < .05f)
            {
                yield return null;
            }
        }
    
    }


}

[System.Serializable]
public class ObjetosTienda
{
    public Objeto objeto;
}
