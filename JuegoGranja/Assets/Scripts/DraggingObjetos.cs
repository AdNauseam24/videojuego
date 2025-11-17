using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggingObjetos : MonoBehaviour,IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public EspacioObjeto espacio;
    public GestorInventario gestorInventario;

    void Start()
    {
        gestorInventario = GameObject.Find("Inventario").GetComponent<GestorInventario>();
    }

    
        //código para que el objeto sea draggeable
       public  Transform parentAfterDrag;
       public UnityEngine.UI.Image image;

    //para cambiar la jerarquía visual cambiamos el padre
    public void OnBeginDrag(PointerEventData eventData)
    {
        if(gestorInventario.GetMenuAbierto())
        {
        gestorInventario.DeseleccionarTodo();
        espacio.seleccionado = true;
        espacio.marcoSeleccion.GetComponent<UnityEngine.UI.Image>().enabled = true;
        Debug.Log("EMpezar");
        parentAfterDrag = transform.parent;
        transform.SetParent(GameObject.FindGameObjectWithTag("Inventario").transform);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
        }
        
    }

    //mientras arrastramos la posicion del objeto será la del ratón
    public void OnDrag(PointerEventData eventData)
    {
        if(gestorInventario.GetMenuAbierto())
        {
       transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
         if(gestorInventario.GetMenuAbierto())
         {
            Debug.Log("Terminar");
            transform.SetParent(parentAfterDrag);
            transform.SetAsLastSibling();
            image.raycastTarget = true;
         }
    }
}
