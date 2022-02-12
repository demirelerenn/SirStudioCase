using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayArea : MonoBehaviour
{
    [SerializeField] private Transform leftWall;
    [SerializeField] private Transform rightWall;
    [SerializeField] private Transform upWall;
    [SerializeField] private Transform downWall;

    public PlayLimit playLimit;

    // Start is called before the first frame update
    void Awake()
    {
        SetLimits();
    }

    private void SetLimits()
    {
        Vector2 xLimits;
        Vector2 zLimits;

        xLimits.x = leftWall.position.x + leftWall.localScale.z;
        xLimits.y = rightWall.position.x - rightWall.localScale.z;

        zLimits.x = downWall.position.z + downWall.localScale.z;
        zLimits.y = upWall.position.z - upWall.localScale.z;

        playLimit = new PlayLimit(xLimits.x, xLimits.y, zLimits.x, zLimits.y);
    }
}

[System.Serializable]
public struct PlayLimit
{
    public Vector2 xLimits;
    public Vector2 zLimits;

    public PlayLimit(float xMin, float xMax, float zMin, float zMax)
    {
        xLimits.x = xMin;
        xLimits.y = xMax;
        zLimits.x = zMin;
        zLimits.y = zMax;
    }
}