using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeEvents : MonoBehaviour
{
    public void SelfDisable()
    {
        gameObject.SetActive(false);
    }

    public void MoveNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
