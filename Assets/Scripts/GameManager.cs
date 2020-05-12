using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager instance;

    [SerializeField] LevelSelections currentLevelSttings;
    [HideInInspector] public string gameMode;
    [HideInInspector] public int totalNumberOfLightUps;
    [HideInInspector] public bool paused;


    public AudioSource gameAudioSource;
    [SerializeField] AudioClip pointGainClip;
    [SerializeField] AudioClip liftOffClip;
    public int score;

    void Awake() 
    {
        if (instance == null)
            instance = this;

        gameMode = currentLevelSttings.gameMode;
        Instantiate(currentLevelSttings.selectedLayout, Vector3.zero, Quaternion.identity);
        if(PlayerPrefs.HasKey("GameVolume"))
            gameAudioSource.volume = PlayerPrefs.GetFloat("GameVolume");
    }

    void Start()
    {
        paused = false;
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
