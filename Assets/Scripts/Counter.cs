using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public static Counter Instance;

    public Slider Laughbar;

    public float sliderVelocity = 0;

    private int combo;

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
        float currentScore = Mathf.SmoothDamp(Laughbar.value, Score, ref sliderVelocity, 100 * Time.deltaTime);
        Laughbar.value = currentScore;


        //Joke-ster positions
        if(Combo < 5)
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
        }
        else if (Score < 25) 
        { 
            Queen0.SetActive(false);
            Queen1.SetActive(true);
            Queen2.SetActive(false);
            Queen3.SetActive(false);
            Queen4.SetActive(false);
            Queen5.SetActive(false);
        }
        else if (Score < 45)
        {
            Queen0.SetActive(false);
            Queen1.SetActive(false);
            Queen2.SetActive(true);
            Queen3.SetActive(false);
            Queen4.SetActive(false);
            Queen5.SetActive(false);
        }
        else if (Score < 65)
        {
            Queen0.SetActive(false);
            Queen1.SetActive(false);
            Queen2.SetActive(false);
            Queen3.SetActive(true);
            Queen4.SetActive(false);
            Queen5.SetActive(false);
        }
        else if (Score < 85)
        {
            Queen0.SetActive(false);
            Queen1.SetActive(false);
            Queen2.SetActive(false);
            Queen3.SetActive(false);
            Queen4.SetActive(true);
            Queen5.SetActive(false);
        }
        else
        {
            Queen0.SetActive(false);
            Queen1.SetActive(false);
            Queen2.SetActive(false);
            Queen3.SetActive(false);
            Queen4.SetActive(false);
            Queen5.SetActive(true);
        }
    }
}