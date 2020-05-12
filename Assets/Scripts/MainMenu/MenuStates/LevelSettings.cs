using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSettings : MenuState
{
    public override void Initialize(MainMenu theMenu)
    {
        pannel = theMenu.levelSettingsPanel;
        base.Initialize(theMenu);
    }
}
