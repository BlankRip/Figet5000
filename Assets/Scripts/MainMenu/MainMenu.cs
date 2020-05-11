using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject levelSettingsPanel;
    public GameObject gameSettingsPanel;
    public GameObject creditsPanel;
    public GameObject controlsPanel;

    Stack<MenuState> menuStack;

    // Start is called before the first frame update
    void Start()
    {
        menuStack = new Stack<MenuState>();
        menuStack.Push(new MainPanel());
        menuStack.Peek().Initialize(this);
    }

    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape) && menuStack.Count > 1)
        PopState();
    }

    public void PlayClicked()
    {
        Debug.Log("<color=green> Play Click Sound</color>");
        SwitchState(new LevelSettings());
    }

    public void SettingsClicked()
    {
        Debug.Log("<color=green> Play Click Sound</color>");
        SwitchState(new GameSettings());
    }

    public void CreditsClicked()
    {
        Debug.Log("<color=green> Play Click Sound</color>");
        SwitchState(new Credits());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowControls()
    {    
        Debug.Log("<color=green> Play Click Sound</color>");
        SwitchState(new Controls());
    }

    public void StartGame()
    {
        Debug.Log("<color=green> Play Click Sound</color>");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void SwitchState(MenuState state)
    {
        menuStack.Peek().Exit();
        menuStack.Push(state);
        menuStack.Peek().Initialize(this);
    }

    public void PopState()
    {
        menuStack.Peek().Exit();
        menuStack.Pop();
        menuStack.Peek().Initialize(this);
    }
}
