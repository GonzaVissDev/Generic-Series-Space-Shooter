using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    private WaveState currentState;
    private GameManager gameManager;
    public List<WaveState> waveStates;
    private int currentWaveIndex = 0;
    private bool wavesComplete = false;

    private void Start()
    {
        gameManager  = GameManager.Instance;
        SetState(waveStates[0]);
    }

    public void SetState(WaveState newState)
    {
        currentState = newState;
        currentState.StartWave();
    }

    public void AdvanceToNextWave()
    {
        currentWaveIndex++;
        if (currentState != null && currentWaveIndex < waveStates.Count)
        {
            SetState(waveStates[currentWaveIndex]); 
        }
        else
        {
            wavesComplete= true;
            gameManager.SetVictory();
            Debug.Log("All waves completed!");
        }
    }

    public void Update()
    {
        if (currentState != null && currentState.CheckWaveComplete() && !wavesComplete)
        {
            AdvanceToNextWave();
        }
    }
}
