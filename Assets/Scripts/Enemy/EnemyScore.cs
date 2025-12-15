using System;
using UnityEngine;

public class EnemyScore : MonoBehaviour
{

    [SerializeField] private int score = 5;
    private Score playerScore;

    public void Start()
    {
        playerScore = GameObject.FindGameObjectWithTag("Player").GetComponent<Score>();
    }

    private void OnDestroy()
    {
        playerScore.incrementScore(score);
    }
    
}
