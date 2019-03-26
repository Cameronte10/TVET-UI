using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour
{
    public bool inGame;
    public GameObject optionsMenu, mainMenu, pauseMenu;
    public void Start()
    {
        if (!inGame)
        {
            optionsMenu = GameObject.Find("Options");
            mainMenu = GameObject.Find("MainMenu");
            optionsMenu.SetActive(false);
            
        }
        else
        {
            pauseMenu = GameObject.Find("PauseMenu");
            pauseMenu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        Time.timeScale = 1;

    }
    public void ChangeScene(int sceneIndex)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneIndex);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();

    }

    public void Options()
    {
        if (!inGame)
        {
            if (optionsMenu.activeSelf)
            {
                optionsMenu.SetActive(false);
                mainMenu.SetActive(true);
            }
            else
            {
                optionsMenu.SetActive(true);
                mainMenu.SetActive(false);
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (inGame)
            {
                if (pauseMenu.activeSelf)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    pauseMenu.SetActive(false);
                    Time.timeScale = 1;
                    
                }
                else
                {
                    pauseMenu.SetActive(true);
                    Time.timeScale = 0;
                    Cursor.lockState = CursorLockMode.Confined;
                    Cursor.visible = true;
                }
            }
        }
    }
}