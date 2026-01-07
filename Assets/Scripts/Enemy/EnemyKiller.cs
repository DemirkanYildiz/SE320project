using System;
using UnityEngine;

public class EnemyKiller : MonoBehaviour
{
    [SerializeField] private GameObject destroy;
    
    public void DestroyObject()
    {
        Destroy(destroy);
    }
}
