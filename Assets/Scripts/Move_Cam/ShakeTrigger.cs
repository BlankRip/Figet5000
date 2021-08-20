using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeTrigger : MonoBehaviour
{
    public float yVel;
    private void OnTriggerEnter(Collider other) {
        //Debug.Log(yVel);
        //Debug.Log(Mathf.Abs((int)(yVel/20)) - 0.7f);
        if(yVel < -30)
            ScreenShake.instance.ShakeCamera(0.5f, Mathf.Abs((int) (yVel/20)) - 0.7f, true);
    }
}
