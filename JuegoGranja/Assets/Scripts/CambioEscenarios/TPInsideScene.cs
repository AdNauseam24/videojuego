using UnityEngine;
using System.Collections;
public class TPInsideScene : MonoBehaviour
{
    public Vector2 nuevaPos;
    private Transform jugador;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            jugador = collision.transform;
            StartCoroutine(DelayFade());
            if(nuevaPos.x == 0.5)
            {
                AudioManager.Instance.ChangeFootsteps(AudioManager.Instance.grassFootsteps);
            }
            else
            {
                AudioManager.Instance.ChangeFootsteps(AudioManager.Instance.woodFootsteps);
            }
        }
    }

    IEnumerator DelayFade()
    {
        GameObject fadeimg = GameObject.FindGameObjectWithTag("Fade");
        while (fadeimg.GetComponent<CanvasGroup>().alpha < 1)
        {
            fadeimg.GetComponent<CanvasGroup>().alpha += 0.1f;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.25f);
        jugador.position = nuevaPos;
        GameObject.FindGameObjectWithTag("MovePoint").transform.position = nuevaPos;

        while (fadeimg.GetComponent<CanvasGroup>().alpha > 0)
        {
            fadeimg.GetComponent<CanvasGroup>().alpha -= 0.1f;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
