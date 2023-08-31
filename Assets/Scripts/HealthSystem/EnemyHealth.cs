using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(DropItem))]
public class EnemyHealth : HealthSystem
{
    [SerializeField] private string deathAnimationName;
    private Animator animator;
    private EnemyManager enemyManager;
    private DropItem dropSystem;

    private void Start()
    {
        enemyManager = EnemyManager.Instance;
        animator = GetComponent<Animator>();
        dropSystem =  GetComponent<DropItem>();
        enemyManager.AddActiveEnemy(this.gameObject);
    }

    protected override void Die()
    {
        animator.Play(deathAnimationName);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
            player.TakeDamage(100);
            ReturnToPool();
        }
    }

    public void ReturnToPool()
    {
        dropSystem.GetItem();
        enemyManager.RemoveActiveEnemy(this.gameObject);
        Destroy(this.gameObject);
    }

}
