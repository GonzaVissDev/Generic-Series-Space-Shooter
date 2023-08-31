using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WaveState : MonoBehaviour
{
    public abstract void StartWave();
    public abstract void UpdateWave();
    public abstract bool CheckWaveComplete();
}
