using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool paused = false;

    public GameObject pauseMenuCanvas;
    public GameObject gameBarsCanvas;

    void Start()
    {
        pauseMenuCanvas.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Pausing");
            if(paused)
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
        pauseMenuCanvas.SetActive(false);
        gameBarsCanvas.SetActive(true);
        Time.timeScale = 1f;
        paused = false;
    }

    void Pause()
    {
        Cursor.visible = true; // Make the cursor visible
        Cursor.lockState = CursorLockMode.None;
        pauseMenuCanvas.SetActive(true);
        gameBarsCanvas.SetActive(false);
        Time.timeScale = 0f;
        paused = true;
    }

    public void MainMenu() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        Debug.Log("Editor Exit Successful");
        #endif
        Application.Quit();
        //PlayerPrefs.DeleteAll();
        Debug.Log("Exit Successful");
    }
}
