﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MenuState
{
    public override void Initialize(MainMenu theMenu)
    {
        pannel = theMenu.controlsPanel;
        base.Initialize(theMenu);
    }
}
