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
        if (this.enabled == false)
            return;
        else
        {
            renderer = GetComponent<Renderer>();
            initialMat = renderer.material;
            runReset = true;
        }
    }

    private void Update()
    {
        if (renderer.material != initialMat && switchBack)
            ResetMat();
    }

    private void OnTriggerExit(Collider other)
    {
        if (this.enabled == true && other.gameObject.CompareTag("Player") && givePoint)
        {
            switchBack = false;
            OnTouchDown();
            givePoint = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.enabled == true && other.gameObject.CompareTag("Player"))
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
