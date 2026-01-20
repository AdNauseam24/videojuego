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
