using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCanvas : MonoBehaviour
{
    public void StartGameButton()
    {
        GameManager.Instance.LoadGameScene();
    }
}
