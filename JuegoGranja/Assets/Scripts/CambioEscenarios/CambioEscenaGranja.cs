using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscenaGranja : MonoBehaviour
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
        if(AudioManager.Instance.GetMusicClip() != AudioManager.Instance.musicaGranja)
        {
            AudioManager.Instance.FadeOutMusic(0.75f);
        }

        GameObject fadeimg = GameObject.FindGameObjectWithTag("Fade");
        while (fadeimg.GetComponent<CanvasGroup>().alpha < 1)
        {
            fadeimg.GetComponent<CanvasGroup>().alpha += 0.1f;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.25f);
        jugador.position = nuevaPos;
        GameObject.FindGameObjectWithTag("MovePoint").transform.position = nuevaPos;
        GameObject.FindGameObjectWithTag("Suelo").GetComponent<Suelo>().MostrarTiles();

        if(AudioManager.Instance.GetMusicClip() != AudioManager.Instance.musicaGranja)
        {
            AudioManager.Instance.PlayMusic(AudioManager.Instance.musicaGranja);
            AudioManager.Instance.FadeInMusic(1.5f);
        }

        AudioManager.Instance.ChangeFootsteps(AudioManager.Instance.grassFootsteps);
        SceneManager.LoadScene(escenaObjetivo);
    }
}
