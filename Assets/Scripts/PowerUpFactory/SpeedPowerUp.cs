using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : PowerUp
{
    private InputMovement playerMovement;
    private float baseSpeed;
    public override void Activate()
    {
       baseSpeed = playerMovement.moveSpeed;
       playerMovement.moveSpeed *= 2;
       base.Activate();
    }
    public override void Deactivate()
    {
        playerMovement.moveSpeed = baseSpeed;
        base.Deactivate();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<InputMovement>() != null)
        {
            playerMovement = collision.gameObject.GetComponent<InputMovement>();
            PowerUpController.Instance.RegisterPowerUp(this);
        }

    }
}
