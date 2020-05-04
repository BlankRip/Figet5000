using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "LigtUpSettings", menuName = "LightUp's Settings")]
public abstract class LightUps : MonoBehaviour
{
    [HideInInspector] public Renderer renderer;
    [HideInInspector] public Material initialMat;
    public Material changeMatTo;

    public void OnTouchDown()
    {
        switchMats(renderer, changeMatTo);
    }

    public void OnLiftOff()
    {
        switchMats(renderer, initialMat);
    }

    void switchMats(Renderer renderer, Material mat)
    {
        renderer.material = mat;
    }
}
