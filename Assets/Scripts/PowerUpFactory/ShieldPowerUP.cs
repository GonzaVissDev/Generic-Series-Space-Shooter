using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUP : PowerUp
{
    [SerializeField] private GameObject shieldObject;
    private GameObject currentShield;
    private Transform playerTransfom; 
    public override void Activate()
    {
      Vector3 playerPosition = playerTransfom.position;
      currentShield =Instantiate(shieldObject, playerPosition, Quaternion.identity);
      currentShield.transform.parent = playerTransfom;

      base.Activate();
    }
    public override void Deactivate()
    {
        Destroy(currentShield);
        base.Deactivate();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerTransfom = collision.transform;
            PowerUpController.Instance.RegisterPowerUp(this);
            this.gameObject.SetActive(false);
        }
    }

}
