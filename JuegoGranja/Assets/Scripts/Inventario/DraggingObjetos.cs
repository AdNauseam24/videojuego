using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggingObjetos : MonoBehaviour,IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private EspacioObjeto espacio;

    private GestorInventario gestorInventario;

    [HideInInspector]
    public Transform parentAfterDrag;

    [SerializeField]
    private UnityEngine.UI.Image image;

    void Start()
    {
        gestorInventario = GameObject.Find("Inventario").GetComponent<GestorInventario>();
        parentAfterDrag = transform.parent;
    }

    //código para que el objeto sea draggeable
       

    //para cambiar la jerarquía visual cambiamos el padre

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(gestorInventario.GetMenuAbierto() && espacio.GetOcupado())
        {
            gestorInventario.DeseleccionarTodo();
            espacio.SetSeleccionado(true);

            parentAfterDrag = transform.parent;
            transform.SetParent(GameObject.FindGameObjectWithTag("Inventario").transform);
            transform.SetAsLastSibling();
            image.raycastTarget = false;
        }
        
    }

    //mientras arrastramos la posicion del objeto será la del ratón
    public void OnDrag(PointerEventData eventData)
    {
        if(gestorInventario.GetMenuAbierto() && espacio.GetOcupado())
        {
            transform.position = Input.mousePosition;
        }
    }

    //Cuando soltamos el objeto
    //Notar que el orden de ejecución es primero OnDrop y luego OnEndDrag
    public void OnEndDrag(PointerEventData eventData)
    {
         if(gestorInventario.GetMenuAbierto())
         {
            transform.SetParent(parentAfterDrag);
            transform.SetAsFirstSibling();
            image.raycastTarget = true;
         }
    }
}
