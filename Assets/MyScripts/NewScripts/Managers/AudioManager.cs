using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource bassAudioSource, rhythmAudioSource, guitarAudioSource, melodyAudioSource;

    [Range(0, 1)]
    [SerializeField] float fadeRate;

    private void Start()
    {
        float tempFadeRate = fadeRate;
        fadeRate = 1;
        ChangeMusic();
        fadeRate = tempFadeRate;
    }

    public void ChangeMusic()
    {
        print(fadeRate);
        switch(StationManager.instance.currentStation)
        {
            case StationManager.Stations.OrderStation:
                StartCoroutine(FadeIn(bassAudioSource));
                StartCoroutine(FadeOut(rhythmAudioSource));
                StartCoroutine(FadeOut(guitarAudioSource));
                StartCoroutine(FadeOut(melodyAudioSource));
                break;
            case StationManager.Stations.BuildStation:
                StartCoroutine(FadeIn(bassAudioSource));
                StartCoroutine(FadeIn(rhythmAudioSource));
                StartCoroutine(FadeOut(guitarAudioSource));
                StartCoroutine(FadeOut(melodyAudioSource));
                break;
            case StationManager.Stations.CookingStation:
                StartCoroutine(FadeIn(bassAudioSource));
                StartCoroutine(FadeIn(rhythmAudioSource));
                StartCoroutine(FadeIn(guitarAudioSource));
                StartCoroutine(FadeOut(melodyAudioSource));
                break;
            case StationManager.Stations.ChipsStation:
                StartCoroutine(FadeIn(bassAudioSource));
                StartCoroutine(FadeOut(rhythmAudioSource));
                StartCoroutine(FadeOut(guitarAudioSource));
                StartCoroutine(FadeIn(melodyAudioSource));
                break;
        }
    }

    private IEnumerator FadeOut(AudioSource source)
    {
        while(source.volume != 0)
        {
            source.volume -= fadeRate;
            yield return null;
        }
    }

    private IEnumerator FadeIn(AudioSource source)
    {
        while (source.volume != 1)
        {
            source.volume += fadeRate;
            yield return null;
        }
    }
}
