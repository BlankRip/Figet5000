using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MenuState
{
    public override void Initialize(MainMenu theMenu)
    {
        pannel = theMenu.gameSettingsPannel;
        base.Initialize(theMenu);
    }
}
