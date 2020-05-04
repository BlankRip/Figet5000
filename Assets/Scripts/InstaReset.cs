using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaReset : LightUps
{
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        initialMat = renderer.material;
    }

    private void OnCollisionEnter(Collision collision)
    {
        OnTouchDown();
    }

    private void OnCollisionExit(Collision collision)
    {
        OnLiftOff();
    }
}
