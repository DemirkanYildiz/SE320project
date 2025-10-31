using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//dungeon finishing logic should be here.
public class DungeonHandler : MonoBehaviour
{

    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform playerStartPoint;
    //[SerializeField] private List<EnemySpawner> enemySpawners;

    public void Awake()
    {
        //enemySpawners = new List<EnemySpawner>();
    }

    public void Start()
    {
        LoadDungeon();
    }

    public void LoadDungeon()
    {
        Instantiate(playerPrefab, playerStartPoint);
        /*foreach (EnemySpawner enemySpawner in enemySpawners)
        {
            Debug.Log("enemy spawned");
            enemySpawner.Spawn();
        }*/
    }
}
