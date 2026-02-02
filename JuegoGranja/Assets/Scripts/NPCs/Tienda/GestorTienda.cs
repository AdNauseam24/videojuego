using System.Collections.Generic;
using UnityEngine;

public class GestorTienda : MonoBehaviour
{
    [SerializeField]private List<ObjetosTienda> objetosTienda;
    [SerializeField] private HuecoTienda[] huecosTienda;

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

    public void IntentarComprar(Objeto objeto)
    {
        if(objeto != null && StatsGenerales.Instance.oro >= objeto.precioCompra)
        {
            StatsGenerales.Instance.RestarOro(objeto.precioCompra);
            GestorInventario.Instance.AddItem(objeto.id,objeto.nombre,1,objeto.sprite);
        }
    }


}

[System.Serializable]
public class ObjetosTienda
{
    public Objeto objeto;
}
