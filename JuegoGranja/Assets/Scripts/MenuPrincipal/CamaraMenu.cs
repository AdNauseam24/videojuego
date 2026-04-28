using System.Collections;
using UnityEngine;

public class CamaraMenu : MonoBehaviour
{

    public AudioClip introMusica;
    public AudioClip loopMusica;
    private new AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        GetComponent<AudioSource>().loop = false;
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
        audio.clip = introMusica;
        audio.PlayOneShot(audio.clip);
        yield return new WaitForSeconds(audio.clip.length-0.5f);
        audio.clip = loopMusica;
        GetComponent<AudioSource>().loop = true;
        audio.Play();
    }
}
