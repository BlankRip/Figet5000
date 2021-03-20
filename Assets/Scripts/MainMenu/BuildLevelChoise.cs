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

    void Start() {
        currentSettings.selectedLayout = threeX;
        currentSettings.showScore = true;
        currentSettings.gameMode = GameMode.Never;
    }


    //For Game Mode selection buttons
    public void InstantSwitchSelected() {
        currentSettings.gameMode = GameMode.Insta;
    }

    public void UltimateFigetSelected() {
        currentSettings.gameMode = GameMode.Timer;
    }

    public void PainterFigetSelected() {
        currentSettings.gameMode = GameMode.Never;
    }


    //For Level Size Selection
    public void ThreeXSelected() {
        currentSettings.selectedLayout = threeX;
    }

    public void FourXSelected() {
        currentSettings.selectedLayout = fourX;
    }

    public void FiveXSelected() {
        currentSettings.selectedLayout = fiveX;
    }

    public void SevenXSelected() {
        currentSettings.selectedLayout = sevenX;
    }


    //For Show Score Setting
    public void OnSelected() {
        currentSettings.showScore = true;
    }

    public void OffSelected() {
        currentSettings.showScore = false;
    }
}
