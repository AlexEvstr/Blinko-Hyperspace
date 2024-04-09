using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static int TotalScore;

    [SerializeField] private TMP_Text _scoreText;

    private void Start()
    {
        TotalScore = PlayerPrefs.GetInt("TotalScore", 0);
    }

    private void Update()
    {
        _scoreText.text = TotalScore.ToString();
    }
}
