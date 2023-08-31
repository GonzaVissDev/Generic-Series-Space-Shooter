using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : ProjectileMovement
{
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    protected override void Movement()
    {
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ITakeDamage damageReceiver = collision.gameObject.GetComponent<ITakeDamage>();

        if (damageReceiver != null)
        {
            damageReceiver.TakeDamage(damage);
        }

        ReturnToPool();
    }
}
