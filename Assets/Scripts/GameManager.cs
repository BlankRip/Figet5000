using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager instance;

    [SerializeField] LevelSelections currentLevelSttings;
    [SerializeField] Vector3 playerSpawnPos = new Vector3(0, 1.6f, 0);
    [SerializeField] GameObject scoreObj;
    [SerializeField] TextMeshProUGUI scoreText;
    [HideInInspector] public string gameMode;
    [HideInInspector] public int totalNumberOfLightUps;
    [HideInInspector] public bool paused;
    [SerializeField] GameObject fadeOut;


    public AudioSource gameAudioSource;
    [SerializeField] AudioClip pointGainClip;
    [SerializeField] AudioClip liftOffClip;
    public int score;

    void Awake() 
    {
        if (instance == null)
            instance = this;

        gameMode = currentLevelSttings.gameMode;
        scoreObj.SetActive(currentLevelSttings.showScore);
        Instantiate(currentLevelSttings.selectedLayout, Vector3.zero, Quaternion.identity);
        if(PlayerPrefs.HasKey("GameVolume"))
            gameAudioSource.volume = PlayerPrefs.GetFloat("GameVolume");
        Instantiate(currentLevelSttings.selectedPlayer, playerSpawnPos, Quaternion.identity);
        
    }

    void Start()
    {
        paused = false;
        totalNumberOfLightUps = FindObjectsOfType<InstaReset>().Length;
        scoreText.text = score.ToString();
        Debug.Log(totalNumberOfLightUps);
    }

    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
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

    public void FadeToNextScene()
    {
        fadeOut.SetActive(true);
    }
}
