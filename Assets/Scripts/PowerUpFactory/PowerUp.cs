using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    [SerializeField] private string powerUpName;
    public string Id => powerUpName;
    
    [SerializeField] private float activationTime;
    public float Time => activationTime;
    
    [SerializeField] public bool isActive = false; // get //SEt

    public virtual void Activate()
    {
            if (!isActive)
            {
                isActive = true;
                this.gameObject.SetActive(false);
            }
    }

    public virtual void  Deactivate()
        {
            isActive = false;
        }

}
