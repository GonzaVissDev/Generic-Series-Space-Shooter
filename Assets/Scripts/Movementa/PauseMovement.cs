using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PauseMovement : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float moveDuration = 3f;

    private Rigidbody2D rb;
    private float currentMoveTime = 0f;
    private bool isMoving = true;

    public void Ejecute()
    {
        if (isMoving)
        {
            rb.velocity = new Vector2(rb.velocity.x, (-moveSpeed));
            currentMoveTime += Time.deltaTime;

            if (currentMoveTime >= moveDuration)
            {
                rb.velocity = Vector2.zero;
                isMoving = false;
            }
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    private void Update()
    {
        if (isMoving)
        {
            rb.velocity = new Vector2(rb.velocity.x,(-moveSpeed));
            currentMoveTime += Time.deltaTime;

            if (currentMoveTime >= moveDuration)
            {
                rb.velocity = Vector2.zero;
                isMoving = false;
            }
        }
    }
}
