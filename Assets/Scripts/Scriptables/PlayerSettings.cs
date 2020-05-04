using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettings", menuName = "Player Settings")]
public class PlayerSettings : ScriptableObject
{
    public float moveSpeed;
    [Range(0, 1)] public float moveSmothness;
    [Range(1, 4)] public float sprintSpeedMultiplier;
    [Range(0, 1)] public float rotationSpeed;
    public float jumpForce;
    public KeyCode jumpKey = KeyCode.Space;
}
