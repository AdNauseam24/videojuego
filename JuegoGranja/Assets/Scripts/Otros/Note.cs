using TMPro;
using UnityEngine;


[System.Serializable]
public class Note : MonoBehaviour
{
    public bool completada;
    public string texto;

    public void Toggle()
    {
        if (completada)
        {
            completada = false;
            GetComponentInChildren<TMP_Text>().fontStyle = FontStyles.Normal;
        }
        else
        {
            completada = true;
            GetComponentInChildren<TMP_Text>().fontStyle = FontStyles.Strikethrough;
        }
    }

    public void SetTrue()
    {
        completada = true;
        GetComponentInChildren<TMP_Text>().fontStyle = FontStyles.Strikethrough;
        
    }

    public void BorrarTarea()
    {
        MenuNotas.Instance.notas.Remove(this);
        Destroy(gameObject);
    }
}
