using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscenaMinas : MonoBehaviour
{
    public string escenaObjetivo;

    //[SerializeField]
    //private Animator animator;

    public Vector2 nuevaPos;
    private Transform jugador;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            jugador = collision.transform;
            //animator.Play("FadeBlanco");
            StartCoroutine(DelayFade());
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
        int x = Random.Range(1,3);
        if(x == 1)
        {
            nuevaPos =  new Vector2(-10.5f,-11.5f);
        }
        else
        {
            nuevaPos =  new Vector2(-12.5f,-21.5f);
        }
        jugador.position = nuevaPos;
        GameObject.FindGameObjectWithTag("MovePoint").transform.position = nuevaPos;
        GameObject.FindGameObjectWithTag("Suelo").GetComponent<Suelo>().OcultarTiles();
        
        SceneManager.LoadScene("Minas" + x);
    }
}
