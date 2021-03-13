using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettings", menuName = "Player Settings")]
public class PlayerSettings : ScriptableObject
{
    public float moveSpeed;
    [Range(1, 4)] public float sprintSpeedMultiplier;
    public float rotationSpeed;
    public float jumpHight;
    public float gravity;
    public KeyCode jumpKey = KeyCode.Space;
}
