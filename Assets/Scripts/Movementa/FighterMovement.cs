using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    bool isMovingLeft = true;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float leftLimit = -10f;
    [SerializeField] private float rightLimit = 10f;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        Movements();
        if (CurrentDirectionisLeft() || CurrentDirectionisRight())
        {
            isMovingLeft = !isMovingLeft;
        }
    }

    public void Movements()
    {
        Vector2 movementDirection = isMovingLeft ? Vector2.left : Vector2.right;
        MoveToDirection(movementDirection);
    }

    public void MoveToDirection(Vector2 direction)
    {
        direction.Normalize();
        rb2d.velocity = direction * moveSpeed;
    }

    public bool CurrentDirectionisLeft()
    {
        return isMovingLeft && transform.position.x <= leftLimit;
    }
    public bool CurrentDirectionisRight()
    {
        return !isMovingLeft && transform.position.x >= rightLimit;
    }
}
