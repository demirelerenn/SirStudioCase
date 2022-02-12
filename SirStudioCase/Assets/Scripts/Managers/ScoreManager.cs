using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : Singleton<ScoreManager>
{
    private int _score;
    public int Score
    {
        get { return _score; }
        set
        {
            _score = value;

            if (_score >= 100)
            {
                SaveLoadData.Instance.SaveScore(_score);
                GameManager.Instance.LoadFinalScene();
            }
        }
    }
}
