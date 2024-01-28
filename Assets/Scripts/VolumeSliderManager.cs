using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderManager : MonoBehaviour
{

    public Slider volumeSlider;

    void Start()
    {
        float volume = PlayerPrefs.GetFloat("volume", 1.0f);
        volumeSlider.value = volume;
    }

    public void OnVolumeSliderChanged()
    {
        float volume = volumeSlider.value;
        Debug.Log("volume changed: " + volume);
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("volume", volume);
    }
}
