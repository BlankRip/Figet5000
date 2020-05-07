using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "LigtUpSettings", menuName = "LightUp's Settings")]
public abstract class LightUps : MonoBehaviour
{
    [HideInInspector] public Renderer renderer;
    [HideInInspector] public Material initialMat;
    [HideInInspector] public bool givePoint = true;
    public Material changeMatTo;

    public void OnTouchDown()
    {
        Debug.Log("<color=cyan> Point Audio Played </color>");
        GameManager.instance.PointAudio();
        GameManager.instance.AddScore();
        switchMats(renderer, changeMatTo);
    }

    public void OnLiftOff()
    {
        GameManager.instance.LiftOffAudio();
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
