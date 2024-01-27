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
        Score = 20;
    }

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        float currentScore = Mathf.SmoothDamp(Laughbar.value, Score, ref sliderVelocity, 100 * Time.deltaTime);
        Laughbar.value = currentScore;
    }
}