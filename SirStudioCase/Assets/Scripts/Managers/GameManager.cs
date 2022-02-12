using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadFinalScene()
    {
        SceneManager.LoadScene(2);
    }
}
