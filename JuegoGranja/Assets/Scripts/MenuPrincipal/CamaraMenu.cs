using System.Collections;
using UnityEngine;

public class CamaraMenu : MonoBehaviour
{

    public AudioClip introMusica;
    public AudioClip loopMusica;
    public AudioSource audio1;
    public AudioSource audio2;
    void Start()
    {
        audio2.volume = 0;
        audio2.loop = true;
        audio1.loop = false;
        audio1.clip = introMusica;
        audio2.clip = loopMusica;
        StartCoroutine(PlayAudio());
        StartCoroutine(Movimiento());
    }

    public IEnumerator Movimiento()
    {
        gameObject.transform.position = new Vector3 (5,37,-10);
        float timeElapsed = 0f;
        float lerpDuration = 110f;
        Vector3 posicionInicial = gameObject.transform.position;
        Vector3 objetivo = new Vector3(5,-390,-10);

         while(timeElapsed < lerpDuration)
        {
            timeElapsed += Time.unscaledDeltaTime;
            gameObject.transform.position = Vector3.Lerp(posicionInicial,objetivo,timeElapsed/lerpDuration);
           
            yield return null;
        }
        StartCoroutine(Movimiento());
    }
    public IEnumerator PlayAudio()
    {
       
        audio1.PlayOneShot(audio1.clip);
        yield return new WaitForSeconds(audio1.clip.length-0.7f);
        audio2.Play();
        audio2.volume = 1;
    }
}
