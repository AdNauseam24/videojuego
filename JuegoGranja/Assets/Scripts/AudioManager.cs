using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
     private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    public float audioMultiplier = 0.5f;

    public float generalMultiplier = 1;
    public float musicMultiplier = 1;
    public float sfxMultiplier = 1;

    [Header("---------Audio Source-----------")]
    [SerializeField]
    AudioSource musicSource;
    [SerializeField]
    AudioSource sfxSource;

    [Header("---------Audio Clips Música-----------")]
    public AudioClip musicaGranja;
    public AudioClip musicaBosque;
    public AudioClip musicaPueblo1;
    public AudioClip musicaPueblo2;
    public AudioClip musicaCuevas;
    public AudioClip musicaTenebrosa;


    [Header("---------Audio Clips SFX-----------")]
    public AudioClip cortarMadera;
    public AudioClip picarPiedra;
    public AudioClip regarPlantas;
    public AudioClip ararSuelo;
    public AudioClip pescar;
    public AudioClip clickMenu;
    public AudioClip menuDenied;
    public AudioClip collectItem;
    public AudioClip treasureFound;
    public AudioClip cuchicheo;
    public AudioClip sorpresa;
    public AudioClip caida;
    public AudioClip derrumbe;
    public AudioClip pocion;
    public AudioClip monstruoDormido;
    public AudioClip rugidoMonstruo1;
    public AudioClip rugidoMonstruo2;
    public AudioClip rugidoLegendario;

    [Header("---------Audio Clips Footsteps-----------")]
    public AudioClip[] grassFootsteps;
    public AudioClip[] woodFootsteps;
    public AudioClip[] sandFootsteps;
    public AudioClip[] rockFootsteps;

    private List<AudioClip> selectedFootsteps = new List<AudioClip>();
    

    void Start()
    {  
        if(StatsGenerales.Instance != null)
        {
            generalMultiplier = StatsGenerales.Instance.volumenGeneral;
            musicMultiplier = StatsGenerales.Instance.volumenMusica;
            sfxMultiplier = StatsGenerales.Instance.volumenSFX;
        }
        musicSource.loop = true;
        musicSource.volume = generalMultiplier * musicMultiplier * audioMultiplier;
       
        if (SceneManager.GetActiveScene().name.Equals("SampleScene"))
        {
            musicSource.clip = musicaGranja; 
            ChangeFootsteps(woodFootsteps);
        }
        else if(SceneManager.GetActiveScene().name.Split("-")[0].Equals("Capitulo1"))
        {
            ChangeFootsteps(rockFootsteps);
            musicSource.clip = musicaTenebrosa;
        }

         musicSource.Play();
      
    }
    public void PlaySFX(AudioClip audioClip)
    {
        sfxSource.PlayOneShot(audioClip,  generalMultiplier * sfxMultiplier);
    }

     public void PlaySFX(AudioClip audioClip, float multiplier)
    {
        sfxSource.PlayOneShot(audioClip,  generalMultiplier * sfxMultiplier * multiplier);
    }
    public void PlayMusic(AudioClip audioClip)
    {
        musicSource.loop = true;
        musicSource.volume = generalMultiplier * musicMultiplier * audioMultiplier;
        musicSource.clip = audioClip;
        musicSource.Play();
    }

    public void PlayMusic(AudioClip audioClip, float multiplier)
    {
        musicSource.loop = true;
        musicSource.volume = generalMultiplier * musicMultiplier * audioMultiplier * multiplier;
        musicSource.clip = audioClip;
        musicSource.Play();
    }
    public void StopMusic()
    {
        musicSource.Stop();
    }

    public IEnumerator FadeOutMusic(float t)
    {
        float timeElapsed = 0f;
        float lerpDuration = t;
        float initialVolume = musicSource.volume;
        while(timeElapsed < lerpDuration)
        {
            timeElapsed += Time.unscaledDeltaTime;
            musicSource.volume = Mathf.Lerp(initialVolume,0,timeElapsed/lerpDuration);
            yield return null;
        }
    }

    public IEnumerator FadeInMusic(float t)
    {
        float timeElapsed = 0f;
        float lerpDuration = t;
        float finalVolume =  StatsGenerales.Instance.volumenGeneral * StatsGenerales.Instance.volumenMusica * audioMultiplier;
        while(timeElapsed < lerpDuration)
        {
            timeElapsed += Time.unscaledDeltaTime;
            musicSource.volume = Mathf.Lerp(0,finalVolume,timeElapsed/lerpDuration);
            yield return null;
        }
    }

    public void ChangeFootsteps(AudioClip[] audio)
    {
        selectedFootsteps.Clear();
        selectedFootsteps.AddRange(audio);
    }

    public void FootStep()
    {
        int r = Random.Range(0, selectedFootsteps.Count);
        sfxSource.PlayOneShot(selectedFootsteps[r],  generalMultiplier * sfxMultiplier * 0.15f);
    }
    public AudioClip GetMusicClip()
    {
        return musicSource.clip;
    }

    public void ChangeMusicVolume()
    {
        generalMultiplier =  StatsGenerales.Instance.volumenGeneral;
        musicMultiplier =  StatsGenerales.Instance.volumenMusica;
        sfxMultiplier = StatsGenerales.Instance.volumenSFX;
        musicSource.volume =  generalMultiplier * musicMultiplier * audioMultiplier;
    }

    public void ChangeMusicVolume(float f)
    {
        musicSource.volume = f;
    }
}
