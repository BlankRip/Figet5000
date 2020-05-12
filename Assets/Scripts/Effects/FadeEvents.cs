using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeEvents : MonoBehaviour
{
    [SerializeField] int sceneIndex;

    public void SelfDisable()
    {
        gameObject.SetActive(false);
    }

    public void MoveNextScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
