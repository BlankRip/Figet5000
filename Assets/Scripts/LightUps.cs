using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "LigtUpSettings", menuName = "LightUp's Settings")]
public abstract class LightUps : MonoBehaviour
{
    [HideInInspector] public Renderer renderer;
    [HideInInspector] public Material initialMat;
    public Material changeMatTo;
    public bool pointAudio = true;

    public void OnTouchDown()
    {
        if (pointAudio) 
            Debug.Log("<color=cyan> Point Audio Played </color>");
        switchMats(renderer, changeMatTo);
    }

    public void OnLiftOff()
    {

    }

    public void ResetMat()
    {
        switchMats(renderer, initialMat);
    }

    void switchMats(Renderer renderer, Material mat)
    {
        renderer.material = mat;
    }
}
