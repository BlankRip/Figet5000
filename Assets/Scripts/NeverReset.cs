using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeverReset : LightUps
{
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && givePoint)
        {
            OnTouchDown();
            givePoint = false;
            if (GameManager.instance.score >= GameManager.instance.totalNumberOfLightUps)
                Debug.Log("<color=blue> Move To Next scene </color>");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnLiftOff();
        }
    }
}
