using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InfoUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string text;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(Time.timeScale == 1)
        {
            Image panelInfo = GameObject.FindGameObjectWithTag("InfoUI").GetComponent<Image>();

            panelInfo.GetComponent<CanvasGroup>().alpha = 1;

            panelInfo.GetComponentInChildren<TMP_Text>().text = text;

            panelInfo.transform.SetParent(gameObject.transform);

            panelInfo.rectTransform.localPosition = new Vector3(0, 75, 0);

            panelInfo.transform.localScale = new Vector3 (1,1,1);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Image panelInfo = GameObject.FindGameObjectWithTag("InfoUI").GetComponent<Image>();

        panelInfo.transform.SetParent(Jugador.Instance.transform);

        panelInfo.GetComponent<CanvasGroup>().alpha = 0;

        panelInfo.transform.localScale = new Vector3 (1,1,1);
    }

    
}
