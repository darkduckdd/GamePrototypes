using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundVolumeController : MonoBehaviour
{
    [Header("Companents")]
    [SerializeField]
    private AudioSource audio;
    [SerializeField]
    private Slider slider;

    [Header("Keys")]
    [SerializeField] private string saveVolumeKey;

    [Header("Parametres")]
    [SerializeField] private float volume;

    [Header("Tag")]
    [SerializeField] private string sliderTag;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        this.volume = PlayerPrefs.GetFloat(this.saveVolumeKey);
        this.audio.volume = this.volume;

        GameObject sliderObj = GameObject.FindGameObjectWithTag(this.sliderTag);

        if (sliderObj != null)
        {
            this.slider = sliderObj.GetComponent<Slider>();
            this.slider.value = this.volume;
        }
        else {
            this.volume = 0.5f;
            this.audio.volume = this.volume;
        }
    }

    private void LateUpdate()
    {
        GameObject sliderObj = GameObject.FindGameObjectWithTag(this.sliderTag);

        if(sliderObj != null)
        {
            this.slider = sliderObj.GetComponent<Slider>();
            this.volume = slider.value;

            if (this.audio.volume != this.volume)
            {
                PlayerPrefs.SetFloat(saveVolumeKey, volume);
            }
        }

        this.audio.volume = this.volume;
    }
}
