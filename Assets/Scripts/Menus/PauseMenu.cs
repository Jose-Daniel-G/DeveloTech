using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject btnPause;
    [SerializeField] private GameObject pauseMenu;
    private bool pausedGame = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausedGame)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Pause()
    {
        pausedGame = true;
        Time.timeScale = 0f;
        btnPause.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        pausedGame = false;
        Time.timeScale = 1f;
        btnPause.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void Restart()
    {
        pausedGame = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //public void MainMenu()
    //{
    //    SceneManager.LoadScene(0);
    //}
    //public void PlayLevel(string levelName)
    
    public void PlayLevel(int levelNumber)
    {
        pausedGame = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(levelNumber);
 
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Debug.Log("Closing the game");
        Application.Quit();
    }
}