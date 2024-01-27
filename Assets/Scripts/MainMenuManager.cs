using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{

    public GameObject creditsPanel;
    private Slider volumeSlider;

    void Start()
    {
        creditsPanel.SetActive(false);
        volumeSlider = FindObjectOfType<Slider>();

        float volume = PlayerPrefs.GetFloat("volume", 1.0f);
        volumeSlider.value = volume;
    }

    public void OnPlayButtonPressed()
    {
        Debug.Log("play button pressed");
        SceneManager.LoadScene("Scenes/GameplayScene");
    }

    public void OnOpenCreditsButtonPressed()
    {
        Debug.Log("open credits button pressed");
        creditsPanel.SetActive(true);
    }

    public void OnCloseCreditsButtonPressed()
    {
        Debug.Log("close credits button pressed");
        creditsPanel.SetActive(false);
    }

    public void OnExitButtonPressed()
    {
        Debug.Log("exit button pressed");
        Application.Quit();
    }

    public void OnVolumeSliderChanged()
    {
        float volume = volumeSlider.value;
        Debug.Log("volume changed: " + volume);
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("volume", volume);
    }
}

