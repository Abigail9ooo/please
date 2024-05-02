using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject levelPicker;
    public GameObject settings;
    public GameObject menuPanel;  // Assign the panel in the inspector

    [Header("Initial Active States")]
    public bool mainMenuActiveOnStart = true;
    public bool levelPickerActiveOnStart = false;
    public bool settingsActiveOnStart = false;
    public bool menuPanelActiveOnStart = false;

    void Start()
    {
        // Set initial active states based on inspector settings
        mainMenu.SetActive(mainMenuActiveOnStart);
        levelPicker.SetActive(levelPickerActiveOnStart);
        settings.SetActive(settingsActiveOnStart);
        menuPanel.SetActive(menuPanelActiveOnStart);

        // Ensure the game time is correct
        if (menuPanelActiveOnStart)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }

    public void ToggleMenu()
    {
        menuPanel.SetActive(!menuPanel.activeSelf);
        Time.timeScale = menuPanel.activeSelf ? 0 : 1;
        Cursor.lockState = menuPanel.activeSelf ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = menuPanel.activeSelf;
    }

    public void ShowMainMenu()
    {
        mainMenu.SetActive(true);
        levelPicker.SetActive(false);
        settings.SetActive(false);
    }

    public void ShowLevelPicker()
    {
        mainMenu.SetActive(false);
        levelPicker.SetActive(true);
        settings.SetActive(false);
    }

    public void ShowSettings()
    {
        mainMenu.SetActive(false);
        settings.SetActive(true);
        levelPicker.SetActive(false);
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        menuPanel.SetActive(true);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
