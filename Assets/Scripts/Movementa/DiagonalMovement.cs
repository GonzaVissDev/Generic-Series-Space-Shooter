using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class DiagonalMovement : MonoBehaviour
{
    private Vector3 player; // Referencia al jugador
    public float moveSpeed = 4f; // Velocidad de movimiento
    public float minRange = 2f; // Rango mínimo de seguimiento
    public float maxRange = 6f; // Rango máximo de seguimiento
    public float rotationSpeed = 180f; // Velocidad de rotación en grados por segundo
    private Quaternion initialRotation;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform.position;
        initialRotation = transform.rotation;
    }
    private void Update()
    {
        Vector3 directionToPlayer = player - transform.position;

        // Calcular la distancia al jugador
        float distanceToPlayer = directionToPlayer.magnitude;

        if (distanceToPlayer <= maxRange && distanceToPlayer >= minRange)
        {
            // Limitar la magnitud del vector de dirección según la distancia máxima
            directionToPlayer = directionToPlayer.normalized * distanceToPlayer;

            // Calcular el ángulo de rotación basado en la dirección de movimiento
            float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
            float targetAngle = 90f + angle;

            // Rotar el objeto del sprite hacia el ángulo calculado
            transform.rotation = Quaternion.Euler(0f, 0f, targetAngle);

            // Mover el enemigo en la dirección diagonal limitada hacia el jugador
            GetComponent<Rigidbody2D>().velocity = directionToPlayer.normalized * moveSpeed;
        }
        else
        {
            // Fuera del rango, detener el movimiento
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
