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

    public GameObject Jester0;
    public GameObject Jester3;
    public GameObject Jester5;
    public GameObject Jester8;

    public GameObject Queen0;
    public GameObject Queen1;
    public GameObject Queen2;
    public GameObject Queen3;
    public GameObject Queen4;
    public GameObject Queen5;

    public Animation gameOverAnimation;

    public TextMeshProUGUI QueenText;
    private string tqueen0 = "Incompetent varlet! Dost thou take delight in disgracing thyself before nobility ?";
    private string tqueen1 = "A jester of thy caliber belongs in the shadows, not the spotlight.";
    private string tqueen2 = "Thou shall Make Me Laugh More.";
    private string tqueen3 = "A rustic charm, fit for those with simpler inclinations.";
    private string tqueen4 = "You know, you are more nimble than you look.";
    private string tqueen5 = "Thy dance hath stirred laughter in our souls, a merry jig of jests!";

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
        Combo = 0;
        Score = 30;
    }

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gamePaused = !gamePaused;
            Time.timeScale = gamePaused ? 0 : 1;
            // Open/close pause menu
        }

        float currentScore = Mathf.SmoothDamp(Laughbar.value, Score, ref sliderVelocity, 100 * Time.deltaTime);
        Laughbar.value = currentScore;


        //Joke-ster positions
        if (Combo < 5)
        {
            Jester0.SetActive(true);
            Jester3.SetActive(false);
            Jester5.SetActive(false);
            Jester8.SetActive(false);
        }
        else if (Combo < 10)
        {
            Jester0.SetActive(false);
            Jester3.SetActive(true);
            Jester5.SetActive(false);
            Jester8.SetActive(false);
        }
        else if (Combo < 15)
        {
            Jester0.SetActive(false);
            Jester3.SetActive(false);
            Jester5.SetActive(true);
            Jester8.SetActive(false);
        }
        else
        {
            Jester0.SetActive(false);
            Jester3.SetActive(false);
            Jester5.SetActive(false);
            Jester8.SetActive(true);
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
            gameOver = true;

            // Pause spawners and arrows
            DisableArrowsForTag("Up");
            DisableArrowsForTag("Left");
            DisableArrowsForTag("Right");
            DisableArrowsForTag("Down");

            DisableSpawners();

            // Play the game over animation
            gameOverAnimation.Play();
        }
    }

    public void LoadGameOverScene()
    {
        SceneManager.LoadScene("Scenes/GameOverScene");
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
}