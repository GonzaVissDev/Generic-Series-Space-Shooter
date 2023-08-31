using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Projectile Type", menuName = "Projectile Type")]
public class BulletPool : ScriptableObject
{
    [SerializeField] private string poolName;
    public string typeName => poolName;

    [SerializeField] private GameObject poolPrefab;
    public GameObject prefabObject => poolPrefab;

    [SerializeField] private int size;
    public int  poolSize => size;

}

