using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelSettings", menuName = "Level Settings")]
public class LevelSelections : ScriptableObject
{
    public GameObject selectedPlayer;
    public GameObject selectedLayout;
    public GameMode gameMode;
    public bool showScore;
}
