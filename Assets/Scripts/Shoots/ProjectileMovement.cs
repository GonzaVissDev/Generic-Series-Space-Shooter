using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileMovement : MonoBehaviour, IPoolable
{
    [SerializeField] protected int damage;
    [SerializeField] protected float speed;
    private string projectileType;

    protected abstract void Movement();

    private void OnEnable()
    {
        Movement();
    }

    public void Initialize(string type)
    {
        projectileType = type;
    }

    public virtual void ReturnToPool()
    {
        if (!string.IsNullOrEmpty(projectileType))
        {
            ProjectilePool.Instance.ReturnProjectile(projectileType, gameObject);
        }
    }
}
