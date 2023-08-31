using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "Wave")]
public class Wave : ScriptableObject
{
    public GameObject[] enemiesPrefab;
    [Range(0.1f, 5f)]public  float spawnInterval;
}