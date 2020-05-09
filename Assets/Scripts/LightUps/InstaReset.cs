using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaReset : LightUps
{
    void Start()
    {
        if (this.enabled == false)
            return;
        else
        {
            renderer = GetComponent<Renderer>();
            initialMat = renderer.material;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.enabled == true && other.gameObject.CompareTag("Player"))
        {
            OnTouchDown();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (this.enabled == true && other.gameObject.CompareTag("Player"))
        {
            OnLiftOff();
            ResetMat();
        }
    }
}
