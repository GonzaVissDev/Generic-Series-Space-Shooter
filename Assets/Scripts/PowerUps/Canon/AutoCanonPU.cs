using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AutoCanonPU : PowerUp
{
    [SerializeField] private GameObject canonObject;
    private GameObject currentShield;
    private Transform playerTransform;

    public override void Activate()
    {
        if (playerTransform != null)
        {
            Vector3 playerPosition = new Vector3(playerTransform.position.x, playerTransform.position.y + 0.2f,-1f);
            currentShield = Instantiate(canonObject, playerPosition, Quaternion.identity);
            currentShield.transform.parent = playerTransform;
        }
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
            playerTransform = collision.transform;
            PowerUpController.Instance.RegisterPowerUp(this);
            this.gameObject.SetActive(false);
        }
       
    }
}
