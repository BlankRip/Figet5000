﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefsCreator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("GameVolume"))
            PlayerPrefs.SetFloat("GameVolume", 1f);

        if(!PlayerPrefs.HasKey("MouseSens"))
            PlayerPrefs.SetFloat("MouseSens", 1.75f);
    }
}
