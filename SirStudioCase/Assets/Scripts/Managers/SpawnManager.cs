using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject gemPrefab;
    [SerializeField] private int maxSpawnCount;
    [SerializeField] private Vector2 spawnCooldownLimits;

    private delegate void SpawnGemEvent(int count);
    private SpawnGemEvent spawnGem = null;
    public delegate void DestroyGemEvent();
    public DestroyGemEvent destroyGem = null;

    private Vector2 xLimits;
    private Vector2 zLimits;

    private PlayArea playArea;   

    private void Awake()
    {
        playArea = GameObject.FindGameObjectWithTag("PlayArea").GetComponent<PlayArea>();
    }

    // Start is called before the first frame update
    void Start()
    {
        GetLimits();

        spawnGem += Spawn;
        destroyGem += DestroyGem;

        spawnGem?.Invoke(5);
    }

    private void DestroyGem()
    {
        float delayTime = Random.Range(spawnCooldownLimits.x, spawnCooldownLimits.y);
        StartCoroutine(DestroyDelay(delayTime));
    }

    IEnumerator DestroyDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        spawnGem?.Invoke(1);
    }

    private void Spawn(int count)
    {
        for (int i = 0; i < count; i++)
        {
            float randomX = Random.Range(xLimits.x + 1, xLimits.y - 1);
            float randomZ = Random.Range(zLimits.x + 1, zLimits.y - 1);
            Vector3 spawnPos = new Vector3(randomX, gemPrefab.transform.position.y, randomZ);

            Gem newGem = Instantiate(gemPrefab, spawnPos, Quaternion.identity).GetComponent<Gem>();
            newGem.spawnManager = this;
        }
    }

    private void GetLimits()
    {
        xLimits = playArea.playLimit.xLimits;
        zLimits = playArea.playLimit.zLimits;
    }
}
