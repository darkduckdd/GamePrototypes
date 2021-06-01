using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public AudioClip[] musicList;

    private int currentTrack;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();

        //Запуск музыки
        PlayMusic();

    }

    public void PlayMusic()
    {
        if (source.isPlaying)
        {
            return;
        }

        currentTrack--;
        if (currentTrack < 0)
        {
            currentTrack = musicList.Length - 1;
        }

        StartCoroutine(WaitForMusicEnd());
    }

    IEnumerator WaitForMusicEnd()
    {
        while (source.isPlaying)
        {
            yield return null;
        }
        NextTrack();    

    }

    public void NextTrack()
    {
        source.Stop();
        currentTrack++;
        if (currentTrack > musicList.Length - 1)
        {
            currentTrack = 0;
        }
        source.clip = musicList[currentTrack];
        source.Play();

        StartCoroutine(WaitForMusicEnd());

    }

    public void PreviousTrack()
    {

        source.Stop();
        currentTrack--;
        if (currentTrack < 0)
        {
            currentTrack = musicList.Length - 1; ;
        }
        source.clip = musicList[currentTrack];
        source.Play();

        StartCoroutine(WaitForMusicEnd());
    }

    public void StopMusic()
    {
        StopAllCoroutines();
        source.Stop();
    }

    public void MuteMusic()
    {
        source.mute = !source.mute;
    }
}
