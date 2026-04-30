using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [Header("---------Audio Source-----------")]
    [SerializeField]
   AudioSource musicSource;
    [SerializeField]
    AudioSource sfxSource;

    [Header("---------Audio Clips Música-----------")]
    public AudioClip musicaGranaja;

    [Header("---------Audio Clips SFX-----------")]
    public AudioClip cortarMadera;
    public AudioClip picarPiedra;
    public AudioClip regarPlantas;
    public AudioClip ararSuelo;
    public AudioClip pescar;

    [Header("---------Audio Clips Footsteps-----------")]
    private List<AudioClip> selectedFootsteps = new List<AudioClip>();
    public AudioClip[] grassFootsteps;

    void Start()
    {  
        musicSource.loop = true;
        musicSource.volume = StatsGenerales.Instance.volumenGeneral * StatsGenerales.Instance.volumenMusica * audioMultiplier;
        musicSource.clip = musicaGranaja;
        musicSource.Play();

        ChangeFootsteps(grassFootsteps);
    }
    public void PlaySFX(AudioClip audioClip)
    {
        sfxSource.PlayOneShot(audioClip,  StatsGenerales.Instance.volumenGeneral * StatsGenerales.Instance.volumenSFX);
    }

     public void PlaySFX(AudioClip audioClip, float multiplier)
    {
        sfxSource.PlayOneShot(audioClip,  StatsGenerales.Instance.volumenGeneral * StatsGenerales.Instance.volumenSFX * multiplier);
    }
    public void PlayMusic(AudioClip audioClip)
    {
        musicSource.loop = true;
        musicSource.volume = StatsGenerales.Instance.volumenGeneral * StatsGenerales.Instance.volumenMusica * audioMultiplier;
        musicSource.clip = audioClip;
        musicSource.Play();
    }

    public void PlayMusic(AudioClip audioClip, float multiplier)
    {
        musicSource.loop = true;
        musicSource.volume = StatsGenerales.Instance.volumenGeneral * StatsGenerales.Instance.volumenMusica * audioMultiplier * multiplier;
        musicSource.clip = audioClip;
        musicSource.Play();
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
        Debug.Log(selectedFootsteps);
    }

    public void FootStep()
    {
        int r = Random.Range(0, selectedFootsteps.Count);
        sfxSource.PlayOneShot(selectedFootsteps[r],  StatsGenerales.Instance.volumenGeneral * StatsGenerales.Instance.volumenSFX * 0.15f);
    }
}
