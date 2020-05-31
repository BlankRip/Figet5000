using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeTest : MonoBehaviour
{
    [SerializeField] float shakeLimit = 3;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            ScreenShake.instance.ShakeCamera(0.5f, shakeLimit, true);
        }
    }
}
