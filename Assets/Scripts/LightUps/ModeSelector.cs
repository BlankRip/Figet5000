using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameMode { Insta, Timer, Death, Never }

public class ModeSelector : MonoBehaviour
{
    InstaReset instantMode;
    TimerReset timerMode;
    DeathReset deathMode;
    NeverReset neverMode;

    // Start is called before the first frame update
    void Start() {
        switch (GameManager.instance.gameMode) {
            case GameMode.Insta:
                instantMode = GetComponent<InstaReset>();
                instantMode.enabled = true;
                break;
            case GameMode.Timer:
                timerMode = GetComponent<TimerReset>();
                timerMode.enabled = true;
                break;
            case GameMode.Death:
                deathMode = GetComponent<DeathReset>();
                deathMode.enabled = true;
                break;
            case GameMode.Never:
                neverMode = GetComponent<NeverReset>();
                neverMode.enabled = true;
                break;
        }
    }
}