using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : PowerUp
{
    public override void Activate()
    {
        base.Activate();
        Debug.Log("Vida AL PLAYER");
    }



private void OnCollisionEnter2D(Collision2D collision)
{
        PowerUpController.Instance.RegisterPowerUp(this);
    }

}
