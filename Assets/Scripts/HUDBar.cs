using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDBar : MonoBehaviour
{
    public static HUDBar instance;

    public TextMeshProUGUI ComboText;
    public TextMeshProUGUI ScoreText;

    public void Awake()
    {
        instance = this;
    }

    public void SetCombo(int Combo)
    {
        ComboText.text = "Combo : " + Combo;
    }

    public void SetScore(int Score)
    {
        ScoreText.text = "Score : " + Score;
    }
}