using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscenaBosque : MonoBehaviour
{
    public string escenaObjetivo;

    //[SerializeField]
    //private Animator animator;

    public Vector2 nuevaPos;
    private Transform jugador;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Trigger");
        if(collision.gameObject.tag == "Player")
        {
            jugador = collision.transform;
            //animator.Play("FadeBlanco");
            StartCoroutine(DelayFade());
        }
    }

    IEnumerator DelayFade()
    {
        yield return new WaitForSeconds(0.1f);
        jugador.position = nuevaPos;
        GameObject.FindGameObjectWithTag("MovePoint").transform.position = nuevaPos;
        GameObject.FindGameObjectWithTag("Suelo").GetComponent<Suelo>().OcultarTiles();
        SceneManager.LoadScene(escenaObjetivo);
    }
}
