using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettings", menuName = "Player Settings")]
public class PlayerSettings : ScriptableObject
{
    [Header("Movement")]
    public float moveSpeed;
    [Range(1, 4)] public float sprintSpeedMultiplier;
    public float rotationSpeed;

    [Header("Jump & Dash")]
    public KeyCode jumpKey = KeyCode.Space;
    public float jumpHight;
    public float gravity;
    public float gravityFallMultiplier = 2;
    public float dashTime = 0.2f;
    public float dashMultiplier = 5;

    [Header("Other")]
    public bool useDash;
}
