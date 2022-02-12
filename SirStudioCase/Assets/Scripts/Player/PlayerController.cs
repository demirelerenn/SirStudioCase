using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;

    [Header("Limits")]
    [SerializeField] private Vector2 xLimits;
    [SerializeField] private Vector2 zLimits;

    //Touch Control
    private Vector3 firstTouchPosition;
    private Vector3 lastTouchPosition;
    private Vector3 direction;
    private bool isTouched;

    private PlayArea playArea;

    private void Awake()
    {
        playArea = GameObject.FindGameObjectWithTag("PlayArea").GetComponent<PlayArea>();
    }

    private void Start()
    {
        GetLimits();
    }

    private void GetLimits()
    {
        xLimits = playArea.playLimit.xLimits;
        zLimits = playArea.playLimit.zLimits;
    }

    void Update()
    {
        InputType();

        if (!isTouched)
            return;

        Movement();
        RotateToDirection();
    }

    private void Movement()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, transform.position + direction, Time.deltaTime * moveSpeed);
        pos = LimitPosition(pos);
        transform.position = pos;
    }

    private void RotateToDirection()
    {
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), rotateSpeed * Time.deltaTime);
        }
    }

    private Vector3 LimitPosition(Vector3 pos)
    {
        float x = Mathf.Clamp(pos.x, xLimits.x, xLimits.y);
        float z = Mathf.Clamp(pos.z, zLimits.x, zLimits.y);

        Vector3 limitedPos = new Vector3(x, pos.y, z);
        return limitedPos;
    }

    private void InputType()
    {

#if UNITY_EDITOR || UNITY_STANDALONE_WIN

        if (!Input.GetMouseButton(0) && !Input.GetMouseButtonUp(0))
        {
            isTouched = false;
        }
        else
        {
            isTouched = true;

            if (Input.GetMouseButtonDown(0))
            {
                firstTouchPosition = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                lastTouchPosition = Input.mousePosition;
            }
            else
            {
                Vector3 screenDirection = Input.mousePosition - firstTouchPosition;
                direction = new Vector3(screenDirection.x, 0, screenDirection.y);
                direction.Normalize();
            }
        }

#else

        if (Input.touchCount > 0)
        {
            isTouched = true;
            var inputTouch = Input.GetTouch(0);

            if (inputTouch.phase == TouchPhase.Began)
            {
                firstTouchPosition = inputTouch.position;
            }
            else if (inputTouch.phase == TouchPhase.Moved || inputTouch.phase == TouchPhase.Stationary)
            {
                Vector3 screenDirection = (Vector3)inputTouch.position - firstTouchPosition;
                direction = new Vector3(screenDirection.x, 0, screenDirection.y);
                direction.Normalize();
            }
            else
            {
                lastTouchPosition = inputTouch.position;
            }
        }
        else
        {
            isTouched = false;
        }

#endif
    }
}
