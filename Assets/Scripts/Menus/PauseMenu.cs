using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : Menu
{
    public static bool gameIsPaused;

    private void Awake()
    {
        Player.OnPause += Pause;
    }

    private void OnDestroy()
    {
        Player.OnPause -= Pause;
    }
    private void Start()
    {
        gameIsPaused = false;
        gameObject.SetActive(false);
    }

    private void Pause()
    {
        gameObject.SetActive(true);
        gameIsPaused = true;
        Time.timeScale = 0.0f;
    }

    public void Resume()
    {
        gameObject.SetActive(false);
        gameIsPaused = false;
        Time.timeScale = 1.0f;
    }

    private void Update()
    {
        if (gameIsPaused) 
        {
            Pause();
        }
        else
        {
            Resume();
        }
    }
}
