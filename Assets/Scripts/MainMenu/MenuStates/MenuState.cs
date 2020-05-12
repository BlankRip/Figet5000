using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : MonoBehaviour
{
    public GameObject pannel;

    public virtual void Initialize(MainMenu theMenu)
    {
        pannel.SetActive(true);
    }

    public void Exit()
    {
        pannel.SetActive(false);
    }
}
