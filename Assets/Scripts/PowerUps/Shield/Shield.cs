using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour, ITakeDamage
{
    [SerializeField] private int shield;
    public void TakeDamage(int damage)
    {
        shield -= damage;
        if (shield <= 0) Destroy(this.gameObject); 
    }

}
