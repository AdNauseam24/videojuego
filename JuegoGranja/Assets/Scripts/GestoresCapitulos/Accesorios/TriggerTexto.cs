using UnityEngine;

public class TriggerTexto : MonoBehaviour
{
   [TextArea(3,5)]public string texto;

    public delegate void MandarTexto(string txt);
    public static event MandarTexto OnMandarTexto;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
             OnMandarTexto(texto);
             if(texto.Equals("A lo lejos oyes una especie de rugido, y lo que parecen gritos de socorro"))
            {
                AudioManager.Instance.PlaySFX(AudioManager.Instance.rugidoMonstruo1);
            }
             Destroy(gameObject);
        }
    }
}
