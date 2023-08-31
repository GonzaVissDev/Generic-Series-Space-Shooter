using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEditor.PlayerSettings;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text gameStatusText;
    [SerializeField] private GameObject uiCanvas;
    [SerializeField] private string victoryText ="Victory";
    [SerializeField] private string gameoverText= "Game Over";

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();

                if (instance == null)
                {
                    GameObject singletonObject = new GameObject("GameManager");
                    instance = singletonObject.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }

    public void SetGameOver()
    {
        ActivateUi(gameoverText);
    }

    public void SetVictory()
    {
        ActivateUi(victoryText);
       
    }

    public void ActivateUi(string titleText) {

        gameStatusText.text = titleText;
        uiCanvas.SetActive(true);
        gameStatusText.gameObject.SetActive(true);

    }

    public void Reset()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void Exit()
    {
        Application.Quit();
    }

}
