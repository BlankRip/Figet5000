using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager instance;

    public string gameMode;
    [HideInInspector] public int totalNumberOfLightUps;
    public AudioSource gameAudioSource;
    [SerializeField] AudioClip pointGainClip;
    [SerializeField] AudioClip liftOffClip;
    public int score;

    void Start()
    {
        if (instance == null)
            instance = this;

        totalNumberOfLightUps = FindObjectsOfType<InstaReset>().Length;
        Debug.Log(totalNumberOfLightUps);
    }

    public void AddScore()
    {
        score++;
        //Update UI Here
    }

    public void PointAudio()
    {
        if (gameAudioSource != null)
        {
            gameAudioSource.Stop();
            gameAudioSource.PlayOneShot(pointGainClip);
        }
    }

    public void LiftOffAudio()
    {
        if (gameAudioSource != null)
        {
            gameAudioSource.PlayOneShot(liftOffClip);
        }
    }
}
