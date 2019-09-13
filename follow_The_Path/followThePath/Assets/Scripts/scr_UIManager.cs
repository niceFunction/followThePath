using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_UIManager : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public void Playgame()
    {
        
        SceneManager.LoadScene("SamuelScene");
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void Resume()
    {
        Time.timeScale = 1;
        GameIsPaused = false;
    }

    public void Pause()
    {
        Time.timeScale = 0;
        GameIsPaused = true;
    }
}
