using UnityEngine;
using System;

public class PlayerHealth : HealthSystem
{
    [SerializeField] private Sprite[] damageSprites;
    private SpriteRenderer spriteRenderer;
    public static event Action playerEvent;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentLife = damageSprites.Length;
    }
    protected override void ActionOnHit()
    {
        if (currentLife < 0 ) 
            currentLife = 0;
        
        spriteRenderer.sprite = damageSprites[currentLife];
    }

    protected override void Die()
    {
        playerEvent?.Invoke();
        Destroy(this.gameObject);
    }

}
