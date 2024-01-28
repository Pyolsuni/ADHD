using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class OpeningCutsceneManager : MonoBehaviour
{
    public void LoadMenuScreen()
    {
        SceneManager.LoadScene("Scenes/MenuScene");
    }
}
