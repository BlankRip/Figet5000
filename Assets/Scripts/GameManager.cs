using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager instance;

    [HideInInspector] public int totalNumberOfLightUps;
    public int score;

    void Start()
    {
        if (instance == null)
            instance = this;

        totalNumberOfLightUps = FindObjectsOfType<LightUps>().Length;
        Debug.Log(totalNumberOfLightUps);
    }

    public void AddScore()
    {
        score++;
        //Update UI Here
    }
}
