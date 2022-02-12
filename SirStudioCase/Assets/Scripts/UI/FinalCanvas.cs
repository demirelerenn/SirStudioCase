using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalCanvas : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    public void RestartGameButton()
    {
        GameManager.Instance.LoadGameScene();
    }

    public void WriteFinalScore()
    {
        scoreText.text = "PUAN: " + SaveLoadData.Instance.LoadScore();
    }
}
