using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllLit : MonoBehaviour
{
    [SerializeField] GameObject fadeOutPanel;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ReturnToMenu()
    {
        fadeOutPanel.SetActive(true);
    }
}
