using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;


public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private TMP_Text livesText;
    [SerializeField] private Transform respawnPosition;
    [SerializeField] private int startingLives = 3;
    private GameManager gameManager;
    private int remainingLives {get;set;}

    private void Start()
    {
        gameManager = GameManager.Instance;
        remainingLives = startingLives;
        UpdateLivesText();
        SpawnPlayer();
    }
    private void SpawnPlayer()
    {
       GameObject currentPlayer = Instantiate(playerPrefab, respawnPosition.position, Quaternion.identity);
    }
    private void OnEnable()
    {
        PlayerHealth.playerEvent += RespawnPlayer;
    }

    private void OnDisable()
    {
        PlayerHealth.playerEvent -= RespawnPlayer;
    }
    private void RespawnPlayer()
    {
        if (remainingLives > 0)
        {
            remainingLives--;
            UpdateLivesText();
            SpawnPlayer();
        }
        else
        {
          gameManager.SetGameOver();
        }
    }

    private void UpdateLivesText()
    {
        livesText.text = "Lives:" + remainingLives;
    }
}
