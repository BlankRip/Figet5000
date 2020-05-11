using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
public GameObject creditsPannel;
public GameObject gameSettingsPannel;
public GameObject levelSettingsPannel;
public GameObject controlsPannel;

Stack<MenuState> menuStack;

    // Start is called before the first frame update
    void Start()
    {
        menuStack = new Stack<MenuState>();
    }

    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape) && menuStack.Count > 1)
        PopState();
    }

    void SwitchState(MenuState state)
    {
        menuStack.Peek().Exit();
        menuStack.Push(state);
        menuStack.Peek().Initialize(this);
    }

    void PopState()
    {
        menuStack.Peek().Exit();
        menuStack.Pop();
        menuStack.Peek().Initialize(this);
    }
}
