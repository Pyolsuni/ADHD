using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{

    private Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        //Slider volumeSlider = GetComponentInParent<Canvas>().GetComponentInChildren<Slider>();
        //Debug.Log(volumeSlider);
        volumeSlider = FindObjectOfType<Slider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayButtonPressed()
    {
        Debug.Log("play button pressed");
    }

    public void OnCreditsButtonPressed()
    {
        Debug.Log("credits button pressed");
    }

    public void OnExitButtonPressed()
    {
        Debug.Log("exit button pressed");
        Application.Quit();
    }

    public void OnVolumeSliderChanged()
    {
        Debug.Log("volume changed: " + volumeSlider.value);
        AudioListener.volume = volumeSlider.value;
    }
}
