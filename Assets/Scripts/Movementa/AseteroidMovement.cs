using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AseteroidMovement : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 30f;
    private void Update()
    {
        Movements();
    }
    public void Movements()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
