using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerReset : LightUps
{
    bool switchBack;
    bool runReset;
    [SerializeField] float waitForSecBeforeReset;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        initialMat = renderer.material;
        runReset = true;
    }

    private void Update()
    {
        if (renderer.material != initialMat && switchBack)
            ResetMat();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && givePoint)
        {
            switchBack = false;
            OnTouchDown();
            givePoint = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnLiftOff();
            if (runReset && renderer.material != initialMat)
            {
                StartCoroutine(ResetTimer());
                runReset = false;
            }
        }
    }

    IEnumerator ResetTimer()
    {
        yield return new WaitForSeconds(waitForSecBeforeReset);
        switchBack = true;
        runReset = true;
        givePoint = true;
    }
}
