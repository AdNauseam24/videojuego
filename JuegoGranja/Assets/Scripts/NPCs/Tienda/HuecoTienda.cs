using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HuecoTienda : MonoBehaviour
{
    public Objeto objeto;
    public TMP_Text nombreObjetotexto;
    public TMP_Text precioTexto;
    public Image imagenObjeto;
    public int id;

    [SerializeField] private GestorTienda gestorTienda;


    public int precioCompra;
    public int precioVenta;
    public void Initialize(Objeto nuevoObjeto)
    {
        objeto = nuevoObjeto;
        imagenObjeto.sprite = objeto.GetSprite();
        nombreObjetotexto.text = objeto.nombre;
        this.precioCompra = objeto.precioCompra;
        this.precioVenta = objeto.precioVenta;
        precioTexto.text = precioCompra.ToString();
        this.id = objeto.id;
    }

    public void OnBuyButtonClicked()
    {
        gestorTienda.IntentarComprar(objeto);
    }
}
