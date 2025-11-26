using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//dungeon finishing logic should be here.
public class DungeonHandler : MonoBehaviour
{

    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform playerStartPoint;

    public void Awake()
    {
        //enemySpawners = new List<EnemySpawner>();
    }

    public void Start()
    {
        Instantiate(playerPrefab, playerStartPoint);
    }
    
}
