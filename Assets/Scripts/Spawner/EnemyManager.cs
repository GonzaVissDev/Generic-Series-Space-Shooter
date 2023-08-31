using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private List<GameObject> activeEnemies = new List<GameObject>();
    public int ActiveEnemyCount => activeEnemies.Count;

    private static EnemyManager instance;

    public static EnemyManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<EnemyManager>();

                if (instance == null)
                {
                    GameObject singletonObject = new GameObject("EnemyManager");
                    instance = singletonObject.AddComponent<EnemyManager>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddActiveEnemy(GameObject enemy)
    {
       activeEnemies.Add(enemy);
    }
    public void RemoveActiveEnemy(GameObject enemy)
    {
        activeEnemies.Remove(enemy);
    }
}
