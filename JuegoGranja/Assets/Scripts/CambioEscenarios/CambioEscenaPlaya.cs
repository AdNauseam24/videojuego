using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscenaPlaya : MonoBehaviour
{
    public string escenaObjetivo;

    public Vector2 nuevaPos;
    private Transform jugador;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            jugador = collision.transform;
            StartCoroutine(DelayFade());
        }
    }

    IEnumerator DelayFade()
    {
        if(AudioManager.Instance.GetMusicClip() != AudioManager.Instance.musicaPueblo1 || AudioManager.Instance.GetMusicClip() != AudioManager.Instance.musicaPueblo2)
        {
            AudioManager.Instance.FadeOutMusic(0.75f);
        }

        GameObject fadeimg = GameObject.FindGameObjectWithTag("Fade");
        while (fadeimg.GetComponent<CanvasGroup>().alpha < 1)
        {
            fadeimg.GetComponent<CanvasGroup>().alpha += 0.1f;
            yield return new WaitForSeconds(0.05f);
        }

        if(AudioManager.Instance.GetMusicClip() != AudioManager.Instance.musicaPueblo1 || AudioManager.Instance.GetMusicClip() != AudioManager.Instance.musicaPueblo2)
        {
            if (escenaObjetivo.Equals("Pueblo1"))
            {
                AudioManager.Instance.PlayMusic(AudioManager.Instance.musicaPueblo1);
                AudioManager.Instance.FadeInMusic(1.5f);
            }
            else if(escenaObjetivo.Equals("Pueblo2"))
            {
                AudioManager.Instance.PlayMusic(AudioManager.Instance.musicaPueblo2);
                AudioManager.Instance.FadeInMusic(1.5f);
            }else if (escenaObjetivo.Equals("Capitulo3-1"))
            {
                AudioManager.Instance.PlayMusic(AudioManager.Instance.musicaBosque);
                AudioManager.Instance.FadeInMusic(1.5f);
            }
        }
        yield return new WaitForSeconds(0.25f);
        jugador.position = nuevaPos;
        GameObject.FindGameObjectWithTag("MovePoint").transform.position = nuevaPos;
        GameObject.FindGameObjectWithTag("Suelo").GetComponent<Suelo>().OcultarTiles();

        SceneManager.LoadScene(escenaObjetivo);
    }
}
