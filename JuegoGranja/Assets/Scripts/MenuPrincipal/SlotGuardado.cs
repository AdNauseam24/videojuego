
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SlotGuardado : MonoBehaviour
{
    public bool ocupado;
    public TMP_Text nombre;
    public TMP_Text dia;
    public TMP_Text oro;
    public Image imagenOro;

    public Image borrado;

 public void ModificarSlot(string nombre, int dia, int oro)
    {
        ocupado = true;

        this.nombre.text = nombre;
        this.dia.text = "Día " + dia;
        this.oro.text = oro.ToString();

        this.dia.gameObject.SetActive(true);
        this.oro.gameObject.SetActive(true);
        imagenOro.gameObject.SetActive(true);
        borrado.gameObject.SetActive(true);
    }

    public void CLickSlot()
    {
        if(ocupado && MenuPrincipal.Instance.modoCargar)
        {
            Guardado.nombreArchivo = nombre.text;
            GestorGranja.cargar = true;
            SceneManager.LoadScene("SampleScene");
        }
        else if (!ocupado)
        {
            MenuPrincipal.Instance.ActivarInputField();
        }
        else if(ocupado && MenuPrincipal.Instance.modoCargar)
        {
            
        }
        
    }

    public void ClickTrash()
    {
        MenuPrincipal.Instance.borrarPartida.gameObject.SetActive(true);
        MenuPrincipal.Instance.slotBorrar = this;
    }

    public void VaciarSlot()
    {
        ocupado = false;

        this.nombre.text = "Ranura Vacía";

        this.dia.gameObject.SetActive(false);
        this.oro.gameObject.SetActive(false);
        imagenOro.gameObject.SetActive(false);
        borrado.gameObject.SetActive(false);
    }

}
