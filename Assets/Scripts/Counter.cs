using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Counter : MonoBehaviour
{
    public static Counter Instance;

    public Slider Laughbar;

    public float sliderVelocity = 0;

    private int combo;
    private bool gameOver = false;
    private bool gamePaused = false;
    private int diff;
    private float endTime;

    public GameObject Crowd0;
    public GameObject Crowd1;
    public GameObject Crowd2;
    public GameObject Crowd3;

    public GameObject Queen0;
    public GameObject Queen1;
    public GameObject Queen2;
    public GameObject Queen3;
    public GameObject Queen4;
    public GameObject Queen5;

    public Animation animationPlayer;

    public GameObject ArrowSpawner_Hard;
    public GameObject ArrowSpawner_Easy;
    public AudioSource Music_Hard;
    public AudioSource Music_Easy;

    public TextMeshProUGUI QueenText;
    private readonly string tqueen0 = "Incompetent varlet! Dost thou take delight in disgracing thyself before nobility ?";
    private readonly string tqueen1 = "A jester of thy caliber belongs in the shadows, not the spotlight.";
    private readonly string tqueen2 = "Thou shall Make Me Laugh More.";
    private readonly string tqueen3 = "A rustic charm, fit for those with simpler inclinations.";
    private readonly string tqueen4 = "You know, you are more nimble than you look.";
    private readonly string tqueen5 = "Thy dance hath stirred laughter in our souls, a merry jig of jests!";

    public RectTransform pausePanel;

    public int Combo
    {
        get
        {
            return combo;
        }
        set
        {
            combo = value;
            HUDBar.instance.SetCombo(combo);
        }
    }

    private int score;

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = Mathf.Min(value,100);
            score = Mathf.Max(score, 0);
            HUDBar.instance.SetScore(score);
        }
    }

    void Start()
    {
        pausePanel.gameObject.SetActive(false);

        Debug.Log(PlayerPrefs.GetInt("difficulty"));
        diff = PlayerPrefs.GetInt("difficulty", 0);
        Debug.Log(diff);
        Combo = 0;
        Score = 30;

        AudioSource currentMusic = null;
        if (diff == 0)
        {
            ArrowSpawner_Easy.SetActive(true);
            currentMusic = Music_Easy;
        }
        if (diff == 1)
        {
            ArrowSpawner_Hard.SetActive(true);
            currentMusic = Music_Hard;
        }
        currentMusic.Play();

        endTime = Time.time + currentMusic.clip.length + 2;
        Debug.Log(endTime);
    }

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }

        float currentScore = Mathf.SmoothDamp(Laughbar.value, Score, ref sliderVelocity, 100 * Time.deltaTime);
        Laughbar.value = currentScore;


        //Public positions
        if (Combo > 4 && Combo < 10)
        {
            Crowd0.SetActive(true);
            Crowd1.SetActive(false);
            Crowd2.SetActive(false);
            Crowd3.SetActive(false);
        }
        else if (Combo > 9 && Combo < 15)
        {
            Crowd0.SetActive(true);
            Crowd1.SetActive(true);
            Crowd2.SetActive(false);
            Crowd3.SetActive(false);
        }
        else if (Combo > 14 && Combo < 20)
        {
            Crowd0.SetActive(true);
            Crowd1.SetActive(true);
            Crowd2.SetActive(true);
            Crowd3.SetActive(false);
        }
        else if (Combo >= 20)
        {
            Crowd0.SetActive(true);
            Crowd1.SetActive(true);
            Crowd2.SetActive(true);
            Crowd3.SetActive(true);
        }
        else
        {
            Crowd0.SetActive(false);
            Crowd1.SetActive(false);
            Crowd2.SetActive(false);
            Crowd3.SetActive(false);
        }

        //Queen positions
        if (Score < 15)
        {
            Queen0.SetActive(true);
            Queen1.SetActive(false);
            Queen2.SetActive(false);
            Queen3.SetActive(false);
            Queen4.SetActive(false);
            Queen5.SetActive(false);
            QueenText.text = tqueen0;
        }
        else if (Score < 25) 
        { 
            Queen0.SetActive(false);
            Queen1.SetActive(true);
            Queen2.SetActive(false);
            Queen3.SetActive(false);
            Queen4.SetActive(false);
            Queen5.SetActive(false);
            QueenText.text = tqueen1;
        }
        else if (Score < 45)
        {
            Queen0.SetActive(false);
            Queen1.SetActive(false);
            Queen2.SetActive(true);
            Queen3.SetActive(false);
            Queen4.SetActive(false);
            Queen5.SetActive(false);
            QueenText.text = tqueen2;
        }
        else if (Score < 65)
        {
            Queen0.SetActive(false);
            Queen1.SetActive(false);
            Queen2.SetActive(false);
            Queen3.SetActive(true);
            Queen4.SetActive(false);
            Queen5.SetActive(false);
            QueenText.text = tqueen3;
        }
        else if (Score < 85)
        {
            Queen0.SetActive(false);
            Queen1.SetActive(false);
            Queen2.SetActive(false);
            Queen3.SetActive(false);
            Queen4.SetActive(true);
            Queen5.SetActive(false);
            QueenText.text = tqueen4;
        }
        else
        {
            Queen0.SetActive(false);
            Queen1.SetActive(false);
            Queen2.SetActive(false);
            Queen3.SetActive(false);
            Queen4.SetActive(false);
            Queen5.SetActive(true);
            QueenText.text = tqueen5;
        }

        if (score == 0 && !gameOver)
        {
            Debug.Log(gameOver);
            gameOver = true;
            ArrowSpawner_Hard.SetActive(false);
            ArrowSpawner_Easy.SetActive(false);
            Music_Hard.Stop();
            Music_Easy.Stop();

            /*
            // Pause spawners and arrows
            DisableArrowsForTag("Up");
            DisableArrowsForTag("Left");
            DisableArrowsForTag("Right");
            DisableArrowsForTag("Down");

            DisableSpawners();*/

            // Play the game over animation
            animationPlayer.Play("delayed_game_over_scene_change");
        }

        if (Time.time > endTime && !gameOver)
        {
            gameOver = true;
            //animationPlayer.Play("delayed_win_scene_change");
            LoadWinScene();
        }
    }

    public void TogglePauseMenu()
    {
        gamePaused = !gamePaused;

        Time.timeScale = gamePaused ? 0 : 1;

        AudioSource currentMusic = null;
        if (diff == 0)
        {
            currentMusic = Music_Easy;
        }
        else
        {
            currentMusic = Music_Hard;
        }

        if (gamePaused)
        {
            currentMusic.Pause();
        }
        else
        {
            currentMusic.Play();
        }

        pausePanel.gameObject.SetActive(gamePaused);
    }

    public void LoadWinScene()
    {
        SceneManager.LoadScene("Scenes/WinScene");
    }

    public void LoadGameOverScene()
    {
        SceneManager.LoadScene("Scenes/GameOverScene");
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Scenes/MenuScene");
    }

    /*private void DisableArrowsForTag(string tag)
    {
        foreach (var item in GameObject.FindGameObjectsWithTag(tag))
        {
            item.GetComponent<ArrowMovement>().enabled = false;
        };
    }

    private void DisableSpawners()
    {
        foreach (var item in GameObject.FindGameObjectsWithTag("Spawner"))
        {
            if (item.GetComponent<SpawnerEasy>() != null)
            {
                item.GetComponent<SpawnerEasy>().StopSpawner();
                Debug.Log("Stopped easy spawner");
            }
            if (item.GetComponent<SpawnerHard>() != null)
            {
                item.GetComponent<SpawnerHard>().StopSpawner();
                Debug.Log("Stopped easy spawner");
            }
        };
    }*/

    public void CleanChildren()
    {
        for (int i = 0; i < ArrowSpawner_Hard.transform.childCount; i++)
        {
            Destroy(ArrowSpawner_Hard.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < ArrowSpawner_Easy.transform.childCount; i++)
        {
            Destroy(ArrowSpawner_Easy.transform.GetChild(i).gameObject);
        }
    }
}