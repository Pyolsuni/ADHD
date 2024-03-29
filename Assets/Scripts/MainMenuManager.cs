using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{

    public GameObject mainMenuButtons;
    public GameObject difficultyButtons;
    public GameObject creditsPanel;

    void Start()
    {
        //DontDestroyOnLoad(target:this);

        mainMenuButtons.SetActive(true);
        difficultyButtons.SetActive(false);
        creditsPanel.SetActive(false);
    }

    public void OnPlayButtonPressed()
    {
        Debug.Log("play button pressed");
        mainMenuButtons.SetActive(false);
        difficultyButtons.SetActive(true);
    }

    public void OnDiffucultyChoicePressed(int difficulty)
    {
        Debug.Log("difficulty chosen: " + difficulty);
        PlayerPrefs.SetInt("difficulty", difficulty);
        SceneManager.LoadScene("Scenes/GameplayScene");
    }

    public void OnDifficultyBackPressed()
    {
        Debug.Log("difficulty back button pressed");
        mainMenuButtons.SetActive(true);
        difficultyButtons.SetActive(false);
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
}

