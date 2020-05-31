using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayPlayerObjs : MonoBehaviour
{
    [SerializeField] LevelSelections settings;
    [SerializeField] GameObject myPrefab;
    [SerializeField] int myIndex;

    private void OnEnable() 
    {
        settings.selectedPlayer = myPrefab;
        PlayerPrefs.SetInt("PlayerIndex", myIndex);
    }
}
