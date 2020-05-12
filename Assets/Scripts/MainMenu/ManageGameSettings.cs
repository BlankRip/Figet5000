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
    [SerializeField] AudioSource[] audioSources;
    Cam currentCam;

    private void Start() 
    {
        volumeSlider.value = PlayerPrefs.GetFloat("GameVolume");
        mouseSensitivitySlider.value = PlayerPrefs.GetFloat("MouseSens");
        volumeVale.text = volumeSlider.value.ToString();
        mouseSensValue.text = mouseSensitivitySlider.value.ToString();
        currentCam = FindObjectOfType<Cam>();
    }

    public void UpdateGameVolume()
    {
        volumeSlider.value = Mathf.Round(volumeSlider.value * 100f) / 100f;
        PlayerPrefs.SetFloat("GameVolume", volumeSlider.value);
        volumeVale.text = volumeSlider.value.ToString();
        for (int i = 0; i < audioSources.Length; i++)
            audioSources[i].volume = volumeSlider.value;
    }

    public void UpdateMouseSens()
    {
        mouseSensitivitySlider.value = Mathf.Round(mouseSensitivitySlider.value * 100f) / 100f;
        PlayerPrefs.SetFloat("MouseSens", mouseSensitivitySlider.value);
        mouseSensValue.text = mouseSensitivitySlider.value.ToString();
        if(currentCam != null)
            currentCam.mouseSensitivity = mouseSensitivitySlider.value;
    }
}
