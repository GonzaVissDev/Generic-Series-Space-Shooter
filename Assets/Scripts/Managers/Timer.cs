using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float duration;
    private float currentTime = 0;
    private bool isRunning = false;

    public void Start()
    {
        currentTime = duration;
        isRunning = true;
    }

    public void Update()
    {
        if (isRunning)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                currentTime = 0;
                isRunning = false;
            }
        }
    }

    public void Init(float duration)
    {
        this.duration = duration;
    }

    public bool IsRunning()
    {
        return isRunning;
    }

    public bool IsFinished()
    {
        return !isRunning;
    }
}
