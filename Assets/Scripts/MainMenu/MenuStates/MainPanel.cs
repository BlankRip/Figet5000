using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPanel : MenuState
{
    public override void Initialize(MainMenu theMenu)
    {
        pannel = theMenu.mainMenuPanel;
        base.Initialize(theMenu);
    }
}
