using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

[RequireComponent(typeof(ColorManager), typeof(Timer))]
public abstract class HealthSystem : MonoBehaviour , ITakeDamage
{
    [SerializeField] protected int currentLife;
    [SerializeField] protected bool isInmune;
    [SerializeField] private float hitDuration;
    private ColorManager colorManager;
    private Timer timer;
    private void Awake()
    {
        colorManager = GetComponent<ColorManager>();
        timer = gameObject.AddComponent<Timer>();
        timer.Init(hitDuration);
    }
    private void Update()
    {
        timer.Update();

        if (timer.IsFinished())
        {
            colorManager.ResetColor();
        }
    }
    public bool IsInmune
    {
        get { return isInmune; }
    }
    public void SetImmunity(bool value)
    {
        isInmune = value;
    }
    public  virtual void TakeDamage(int damage)
    {
        if (!isInmune)
        {
            currentLife -= damage;
        } 

        ActionOnHit();

        if (currentLife <= 0)
        {
            currentLife= 0;
            Die();
        }
    }
    protected virtual void ActionOnHit()
    {
        colorManager.SetHitColor();
        timer.Start();

    }
    protected abstract void Die();

}
