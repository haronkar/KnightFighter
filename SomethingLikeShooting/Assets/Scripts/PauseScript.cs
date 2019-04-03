using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public static bool isActive = false;

    public GameObject pauseMenuUI;
    public GameObject gameUI;
    public GameObject quitToMenuUI;
    public GameObject quitGameUI;
    public GameObject textObj;
    public GameObject gameOver;

    void Update()
    {
        if (Player_Stats.health <= 0)
            GameOver();

        if (Input.GetKeyDown(KeyCode.Escape) && !textObj.activeInHierarchy)
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        gameOver.SetActive(false);
        pauseMenuUI.SetActive(false);
        gameUI.SetActive(true);
        quitToMenuUI.SetActive(false);
        quitGameUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        pauseMenuUI.SetActive(false);
        gameUI.SetActive(false);
        quitToMenuUI.SetActive(false);
        quitGameUI.SetActive(false);
        Time.timeScale = 0f;
        gameIsPaused = false;
    }

    public void Restart()
    {
        gameOver.SetActive(false);
        pauseMenuUI.SetActive(false);
        gameUI.SetActive(true);
        quitToMenuUI.SetActive(false);
        quitGameUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Pause()
    {
        gameOver.SetActive(false);
        pauseMenuUI.SetActive(true);
        gameUI.SetActive(false);
        quitToMenuUI.SetActive(false);
        quitGameUI.SetActive(false);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting!!");
        Application.Quit();
    }

    public void LoadQuitToMenu()
    {
        gameOver.SetActive(false);
        pauseMenuUI.SetActive(false);
        gameUI.SetActive(false);
        quitToMenuUI.SetActive(true);
        quitGameUI.SetActive(false);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void QuitGameMneu()
    {
        gameOver.SetActive(false);
        pauseMenuUI.SetActive(false);
        gameUI.SetActive(false);
        quitToMenuUI.SetActive(false);
        quitGameUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Panel()
    {
        gameOver.SetActive(false);
        pauseMenuUI.SetActive(false);
        gameUI.SetActive(false);
        quitToMenuUI.SetActive(false);
        quitGameUI.SetActive(false);
        Time.timeScale = 0f;
        isActive = true;
        gameIsPaused = true;
    }

    
}
