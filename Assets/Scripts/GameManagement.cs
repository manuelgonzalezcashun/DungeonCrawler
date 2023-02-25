using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject PausePanel;

    private int currentScene;
    public bool gameIsPaused;

    private static GameManagement instance;

    private void Awake()
    {
        if (instance != null)
            Debug.LogWarning("Found more than one GameManagement in the Scene");

        instance = this;
    }
    public static GameManagement GetInstance()
    {
        return instance;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartLevel()
    {
        StartGame();
    }
    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
    void PauseGame()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        PausePanel.SetActive(false);
        gameIsPaused = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (gameIsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public bool playerisDead()
    {
        if (gameOverPanel.activeInHierarchy)
            return true;
        else
            return false;
    }
    public int GetCurrentScene()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        return currentScene;
    }
}
