using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManageGameSettings : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider mouseSensitivitySlider;
    [SerializeField] TextMeshProUGUI volumeVale;
    [SerializeField] TextMeshProUGUI mouseSensValue;

    private void Start() 
    {
        volumeSlider.value = PlayerPrefs.GetFloat("GameVolume");
        mouseSensitivitySlider.value = PlayerPrefs.GetFloat("MouseSens");
        volumeVale.text = volumeSlider.value.ToString();
        mouseSensValue.text = mouseSensitivitySlider.value.ToString();
    }

    public void UpdateGameVolume()
    {
        PlayerPrefs.SetFloat("GameVolume", volumeSlider.value);
        volumeVale.text = volumeSlider.value.ToString();
        if(GameManager.instance != null)
            GameManager.instance.gameAudioSource.volume = PlayerPrefs.GetFloat("GameVolume");
    }

    public void UpdateMouseSens()
    {
        PlayerPrefs.SetFloat("MouseSens", mouseSensitivitySlider.value);
        mouseSensValue.text = mouseSensitivitySlider.value.ToString();
    }
}
