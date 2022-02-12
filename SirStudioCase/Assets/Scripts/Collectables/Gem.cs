using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    [HideInInspector] public SpawnManager spawnManager;
    [SerializeField] private int scoreValue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.Instance.Score += scoreValue;
            UIManager.Instance.scoreCanvas.UpdateScoreText();
            spawnManager.destroyGem?.Invoke();
            Destroy(gameObject);
        }
    }
}
