using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    private static PowerUpController instance;

    [SerializeField] private Dictionary<string, PowerUp> activePowerUps = new Dictionary<string, PowerUp>();
    public static PowerUpController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PowerUpController>();
                if (instance == null)
                {
                    GameObject managerObject = new GameObject("PowerUpManager");
                    instance = managerObject.AddComponent<PowerUpController>();
                }
            }
            return instance;
        }
    }

    private void Start()
    {
            activePowerUps.Clear();
    }

    public void RegisterPowerUp(PowerUp powerUp)
    {
        if (!activePowerUps.ContainsKey(powerUp.Id))
        {
            activePowerUps.Add(powerUp.Id,powerUp);
            powerUp.Activate();
            StartCoroutine(UnregisterPowerUp(powerUp));
            Debug.Log("Power-up added: " + powerUp.Id);
        }
        else
        {
       
            Debug.Log("Power-up already exists: " + powerUp.Id);
        }

    }
    public IEnumerator UnregisterPowerUp(PowerUp powerUpToRemove)
    {
        if (activePowerUps.ContainsKey(powerUpToRemove.Id))
        {

            yield return new WaitForSeconds(powerUpToRemove.Time);
            activePowerUps[powerUpToRemove.Id].Deactivate();
            activePowerUps.Remove(powerUpToRemove.Id);
            Debug.Log("Power-up removed: " + powerUpToRemove.Id);
        }
    }
}
