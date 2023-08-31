using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
   [SerializeField] private List<BulletPool> projectileTypes = new List<BulletPool>();
    private Dictionary<string, Queue<GameObject>> pooledProjectiles = new Dictionary <string, Queue<GameObject>>();
    private static ProjectilePool instance;
    public static ProjectilePool Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        foreach (var type in projectileTypes)
        {
            Queue<GameObject> projectileQueue = new Queue<GameObject>();
            
            for (int i = 0; i < type.poolSize; i++)
            {
                GameObject projectile = Instantiate(type.prefabObject);
                projectile.GetComponent<IPoolable>().Initialize(type.typeName);
                projectile.SetActive(false);
                projectileQueue.Enqueue(projectile);
            }
            pooledProjectiles.Add(type.typeName, projectileQueue);
        }
    }
    public GameObject GetProjectile(string typeName)
    {
        if (pooledProjectiles.ContainsKey(typeName))
        {
            if (pooledProjectiles[typeName].Count > 0)
            {
                GameObject projectile = pooledProjectiles[typeName].Dequeue();
                projectile.SetActive(true);
                return projectile;
            }else
            {
                AddToPool(typeName, 5);
                GameObject projectile = pooledProjectiles[typeName].Dequeue();
                projectile.SetActive(true);
                return projectile;
            }
        }

        Debug.LogWarning("Projectile type not found: " + typeName);
        return null;
    }
    public void AddToPool(string typeName, int amount)
    {
        foreach (var type in projectileTypes)
        {
            if (type.typeName == typeName)
            {
                for (int i = 0; i < amount; i++)
                {
                    GameObject newProjectile = Instantiate(type.prefabObject);
                    newProjectile.GetComponent<IPoolable>().Initialize(type.typeName);
                    newProjectile.SetActive(false);
                    pooledProjectiles[typeName].Enqueue(newProjectile);
                    
                }
                return;
            }
        }
        Debug.LogWarning("Projectile type not found: " + typeName);
    }
    public void ReturnProjectile(string typeName, GameObject projectile)
    {
        if (pooledProjectiles.ContainsKey(typeName))
        {
            projectile.SetActive(false);
            pooledProjectiles[typeName].Enqueue(projectile);
        }
        else
        {
            Debug.LogWarning("Projectile type not found: " + typeName);
        }
    }
}