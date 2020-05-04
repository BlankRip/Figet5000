using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeverReset : LightUps
{
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnTouchDown();
            pointAudio = false;
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
