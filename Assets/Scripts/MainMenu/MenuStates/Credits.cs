using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MenuState
{
    public override void Initialize(MainMenu theMenu)
    {
        pannel = theMenu.creditsPanel;
        base.Initialize(theMenu);
    }
}
