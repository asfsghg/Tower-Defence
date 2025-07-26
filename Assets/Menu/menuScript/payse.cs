using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false; // есть ли паузаа 
    public GameObject pauseMenuUI;       // панель паузы

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
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
        pauseMenuUI.SetActive(false); 
        Time.timeScale = 1f;          
        isPaused = false;            
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);  
        Time.timeScale = 0f;          
        isPaused = true;             
    }

    public void LoadGame(string sceneName)
    {
        Time.timeScale = 1f;          
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
