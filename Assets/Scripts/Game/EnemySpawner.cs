using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private GameObject enemyPrefab;

    public void Start()
    {
        Instantiate(enemyPrefab, transform);
    }
    
}
