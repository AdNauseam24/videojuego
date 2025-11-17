using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggingObjetos : MonoBehaviour,IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public EspacioObjeto espacio;

    
        //código para que el objeto sea draggeable
       public  Transform parentAfterDrag;
       public UnityEngine.UI.Image image;

    //para cambiar la jerarquía visual cambiamos el padre
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("EMpezar");
        parentAfterDrag = transform.parent;
        transform.SetParent(GameObject.FindGameObjectWithTag("Inventario").transform);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
        
    }

    //mientras arrastramos la posicion del objeto será la del ratón
    public void OnDrag(PointerEventData eventData)
    {
       
       transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Terminar");
       transform.SetParent(parentAfterDrag);
        transform.SetAsLastSibling();
        image.raycastTarget = true;
    }
}
