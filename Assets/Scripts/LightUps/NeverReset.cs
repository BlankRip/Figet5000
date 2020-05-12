using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeverReset : LightUps
{
    void Start()
    {
        if (this.enabled == false)
            return;
        else
            renderer = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.enabled == true && other.gameObject.CompareTag("Player") && givePoint)
        {
            OnTouchDown();
            givePoint = false;
            if (GameManager.instance.score >= GameManager.instance.totalNumberOfLightUps)
                GameManager.instance.FadeToNextScene();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (this.enabled == true && other.gameObject.CompareTag("Player"))
        {
            OnLiftOff();
        }
    }
}
