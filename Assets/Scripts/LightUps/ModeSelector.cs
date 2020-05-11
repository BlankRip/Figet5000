using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSelector : MonoBehaviour
{
    InstaReset instantMode;
    TimerReset timerMode;
    DeathReset deathMode;
    NeverReset neverMode;

    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.instance.gameMode == "Insta")
        {
            instantMode = GetComponent<InstaReset>();
            instantMode.enabled = true;
        }
        else if (GameManager.instance.gameMode == "Timer")
        {
            timerMode = GetComponent<TimerReset>();
            timerMode.enabled = true;
        }
        else if (GameManager.instance.gameMode == "Death")
        {
            deathMode = GetComponent<DeathReset>();
            deathMode.enabled = true;
        }
        else if (GameManager.instance.gameMode == "Never")
        {
            neverMode = GetComponent<NeverReset>();
            neverMode.enabled = true;
        }
    }
}
