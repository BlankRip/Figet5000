using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject settingsPanel;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!GameManager.instance.paused)
            {
                Time.timeScale = 0;
                pausePanel.SetActive(true);
                GameManager.instance.paused = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
                ResumeClicked();
        }
    }

    public void ResumeClicked()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        GameManager.instance.paused = false;
    }

    public void SettingsClicked()
    {
        pausePanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void BackToPause()
    {
        settingsPanel.SetActive(false);
        pausePanel.SetActive(true);
    }

    public void BackToMenuClicked()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
