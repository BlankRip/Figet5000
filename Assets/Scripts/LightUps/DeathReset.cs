using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathReset : LightUps
{
    void Start()
    {
        if (this.enabled == false)
            return;
        else
        {
            renderer = GetComponent<Renderer>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.enabled == true && other.gameObject.CompareTag("Player"))
        {
            if (givePoint)
            {
                OnTouchDown();
                givePoint = false;
            }
            else
                Debug.Log("<color=red> Died Move Scene </color>");

            if (GameManager.instance.score >= GameManager.instance.totalNumberOfLightUps)
                Debug.Log("<color=blue> Move To Next scene </color>");
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
