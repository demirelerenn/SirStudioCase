using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCanvas : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    private void Start()
    {
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        scoreText.text = "PUAN: " + ScoreManager.Instance.Score.ToString();
    }
}
