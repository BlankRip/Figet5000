using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildLevelChoise : MonoBehaviour
{
[SerializeField] LevelSelections currentSettings;
[SerializeField] GameObject threeX;
[SerializeField] GameObject fourX;
[SerializeField] GameObject fiveX;
[SerializeField] GameObject sevenX;

    // Start is called before the first frame update
    void Start()
    {
        currentSettings.selectedLayout = threeX;
        currentSettings.showScore = true;
        currentSettings.gameMode = "Never";
    }


    //For Game Mode selection buttons
    public void InstantSwitchSelected()
    {
        currentSettings.gameMode = "Insta";
    }

    public void UltimateFigetSelected()
    {
        currentSettings.gameMode = "Timer";
    }

    public void PainterFigetSelected()
    {
        currentSettings.gameMode = "Never";
    }


    //For Level Size Selection
    public void ThreeXSelected()
    {
        currentSettings.selectedLayout = threeX;
    }

    public void FourXSelected()
    {
        currentSettings.selectedLayout = fourX;
    }

    public void FiveXSelected()
    {
        currentSettings.selectedLayout = fiveX;
    }

    public void SevenXSelected()
    {
        currentSettings.selectedLayout = sevenX;
    }


    //For Show Score Setting
    public void OnSelected()
    {
        currentSettings.showScore = true;
    }

    public void OffSelected()
    {
        currentSettings.showScore = false;
    }
}
