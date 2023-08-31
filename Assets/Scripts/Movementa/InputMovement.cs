using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputMovement : MonoBehaviour
{
    [SerializeField] private float enableControlDelay = 0.5f;
    public float moveSpeed = 1.0f;
    private bool canMove = true;
    private PlayerHealth playerHealth;
    private Animator anim;
    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        anim = GetComponentInChildren<Animator>();   
        SpawnPosition();
    }
    public void Update()
    {
        if (canMove)
        {
            anim.SetFloat("Speed", moveSpeed);
            Movements();
        }
    }
    public void Movements()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(moveSpeed * Time.deltaTime * new Vector3(horizontalInput,0f, 0f));
    }
    public void SpawnPosition()
    {
        canMove = false;
        Vector3 finalPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 0.5f, Screen.height * 0.2f, 0));
        finalPosition.z = 0;
        StartCoroutine(MoveToPosition(finalPosition, enableControlDelay));
    }
    public IEnumerator MoveToPosition(Vector3 targetPosition, float duration)
    {
        float elapsedTime = 0;
        Vector3 startingPosition = transform.position;
        playerHealth.SetImmunity(true);
        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startingPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
        playerHealth.SetImmunity(false);
        canMove = true;
    }
}
