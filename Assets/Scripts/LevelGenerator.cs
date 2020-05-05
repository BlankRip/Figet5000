﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] cornerPieces;
    [SerializeField] GameObject[] edgePieces;
    [SerializeField] GameObject[] middlePieces;

    GameObject[] cornerSpawnPoints;
    GameObject[] edgeSpawnPoints;
    GameObject[] middleSpwanPoints;
    int pick;
    int previousPick;

    // Start is called before the first frame update
    void Start()
    {
        cornerSpawnPoints = GameObject.FindGameObjectsWithTag("CornerTile");
        middleSpwanPoints = GameObject.FindGameObjectsWithTag("MiddleTile");
        edgeSpawnPoints = GameObject.FindGameObjectsWithTag("EdgeTile");
        LoopSelectSpawn(cornerPieces, cornerSpawnPoints);
        LoopSelectSpawn(edgePieces, edgeSpawnPoints);
        LoopSelectSpawn(middlePieces, middleSpwanPoints);
    }

    void LoopSelectSpawn(GameObject[] spawnObjs, GameObject[] spawnPoints)
    {
        previousPick = 0;
        foreach(GameObject obj in spawnPoints)
        {
            pick = Random.Range(0, spawnObjs.Length);
            if(pick == previousPick)
            {
                if (pick == spawnObjs.Length - 1)
                    pick--;
                else
                    pick++;
            }
            previousPick = pick;
            Instantiate(spawnObjs[pick], obj.transform.position, obj.transform.rotation);
        }
    }
}
