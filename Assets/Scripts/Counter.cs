using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public static Counter Instance;

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
            HUDBar.instance.SetScore(score);
        }
    }

    void Start()
    {
        Combo = 0;
        Score = 50;
    }

    private void Awake()
    {
        Instance = this;
    }
}