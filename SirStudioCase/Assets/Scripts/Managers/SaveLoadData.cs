using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadData : Singleton<SaveLoadData>
{
    private const string score = "score";

    public void SaveScore(int _score)
    {
        PlayerPrefs.SetInt(score, _score);
    }

    public int LoadScore()
    {
        return PlayerPrefs.GetInt(score);
    }
}
