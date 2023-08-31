using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[RequireComponent(typeof(PowerUpFactory))]
public class DropItem : MonoBehaviour
{
    [SerializeField] private PowerUp[] powerUpItem;
    [Range(0.1f, 1)]
    [SerializeField] private float dropChace = 0.5f;
    private PowerUpFactory powerUps;

    private void Awake()
    {
        powerUps = GetComponent<PowerUpFactory>();
    }

    public void GetItem()
    {
        if (Random.Range(0f, 1f) <= dropChace)
        {
            int randomItem = Random.Range(0, powerUpItem.Length);
            powerUps.Create(powerUpItem[randomItem].Id, this.gameObject.transform);
        }

    }
}
