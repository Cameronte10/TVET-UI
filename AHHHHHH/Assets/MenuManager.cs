using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour
{
    public GameObject optionsMenu, mainMenu;
    public void Start()
    {
        optionsMenu = GameObject.Find("Options");
        mainMenu = GameObject.Find("MainMenu");
        optionsMenu.SetActive(false);
    }
    public void ChangeScene(int sceneIndex)
    {
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
